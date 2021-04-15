from django.contrib.auth import authenticate, login
from django.contrib.auth.models import User, UserManager
from django.db.models import Model
from django.shortcuts import get_object_or_404
from rest_framework import generics, status
from rest_framework.views import APIView
from rest_framework.response import Response
from rest_framework.authentication import TokenAuthentication
from rest_framework.authtoken.models import Token
from rest_framework.permissions import IsAuthenticated

from ..models import *
from .serializers import *
from .backendconnection import BackendConnection


# TODO: Add statuses
class SignUpView(APIView):
    def post(self, request, format=None):
        serializer = SignInSerializer(data=request.data)
        if serializer.is_valid():
            valid_data = serializer.validated_data
            newuser = User(username=valid_data['username'],
                email=valid_data['email'])
            newuser.set_password(valid_data['password'])
            newuser.save()
            return Response({'response': 'User created'})
        else:
            return Response(serializer.errors)


class SignInView(APIView):
    def post(self, request, format=None):
        serializer = SignInSerializer(data=request.data)
        if serializer.is_valid():
            valid_data = serializer.validated_data
            username = ''.join(ch for ch in valid_data['username'] if ch.isalnum())
            user = get_object_or_404(User, username=username)
            token, created = Token.objects.get_or_create(user=user)
            return Response({'token': f'{token.key}'})
        else:
            return Response(serializer.errors)


class SearchGameView(APIView):
    def post(self, request, format=None):
        serializer = SearchGameSerializer(data=request.data)
        if serializer.is_valid():
            valid_data = serializer.validated_data
            username = ''.join(ch for ch in valid_data['username'] if ch.isalnum())
            user = get_object_or_404(User, username=username)
            authtoken = BackendConnection(user.username).getauthtoken()
            # deck = get_object_or_404(Deck, user=user, pk=valid_data['deckid'])
            return Response({'token': authtoken})
        else:
            return Response(serializer.errors)


class DeckView(APIView):
    authentication_classes = [TokenAuthentication]
    permission_classes = [IsAuthenticated]

    def get(self, request, format=None):
        player = get_object_or_404(PlayerAccount, player=request.user)
        deck = Deck.objects.filter(owner=player).order_by('pk').first()
        if deck is None:
            return Response({'success': False, 'deck': None})
        else:
            return Response({'success': True, 'deck': DeckSerializer(deck).data})
        # serializer = GetDeckRequestSerializer(request.data)
        # if serializer.is_valid:
        #     valid_data = serializer.validated_data
        #     deck = get_object_or_404(Deck, pk=valid_data['deckid'], owner=request.user)
        #     return Response(DeckSerializer(deck).data)
        # else:
        #     return Response(serializer.errors)


    def put(self, request, format=None):
        serializer = DeckSerializer(data=request.data)
        if serializer.is_valid():
            valid_data = serializer.validated_data
            print(valid_data)
            player = get_object_or_404(PlayerAccount, player=request.user)
            deck = get_object_or_404(Deck, owner=player, pk=valid_data['id'])
            new_card_ids = set(c['card']['id'] for c in valid_data['cards'])
            curr_card_instances = list(CardInstance.objects.filter(deck=deck))
            curr_card_ids = set(inst.card.id for inst in curr_card_instances)
            new_card_instances = [
                CardInstance(deck=deck,
                    card=get_object_or_404(CardOwned, pk=cardid, owner=player))
                for cardid in new_card_ids - curr_card_ids]
            old_card_instances = [
                get_object_or_404(CardInstance, deck=deck,
                    card=get_object_or_404(CardOwned, pk=cardid))
                for old_id in curr_card_ids - new_card_ids]
            for inst in old_card_instances:
                inst.delete()
            for inst in new_card_instances:
                inst.save()
            return Response({'editted': True})
        else:
            return Response(serializer.errors)
