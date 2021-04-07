from django.contrib.auth import authenticate, login
from django.contrib.auth.models import User, UserManager
from django.db.models import Model
from django.shortcuts import get_object_or_404
from rest_framework import generics, status
from rest_framework.views import APIView
from rest_framework.response import Response
from rest_framework.authtoken.models import Token

from ..models import *
from .serializers import *
from .matchqueue import MatchQueueConnection


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
			gametoken = MatchQueueConnection(user.username).get_game_token()
			# deck = get_object_or_404(Deck, user=user, pk=valid_data['deckid'])
			return Response({'token': gametoken})
