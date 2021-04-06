from django.contrib.auth.models import User
from rest_framework import serializers

from ..models import PlayerAccount, Deck, CardOwned, CardInstance, Match


class MatchSerializer(serializers.ModelSerializer):
	class Meta:
		model = Match
		fields = ['starttime']


class CardOwnedSerializer(serializers.ModelSerializer):
	class Meta:
		model = CardOwned
		fields = ['id', 'cardid']


class CardInstanceSerializer(serializers.ModelSerializer):
	class Meta:
		model = CardInstance
		fields = ['card']


class DeckSerializer(serializers.ModelSerializer):
	cards = CardInstanceSerializer(many=True)
	
	class Meta:
		model = Deck
		fields = ['id', 'deckname', 'cards']


class PlayerAccountSerializer(serializers.ModelSerializer):
	decks = DeckSerializer(many=True)
	cards = CardOwnedSerializer(many=True)

	class Meta:
		model = PlayerAccount
		fields = ['username', 'rating', 'cards', 'decks']


class SignInSerializer(serializers.Serializer):
	password = serializers.CharField(style={'input_type': 'password'}, write_only=True)
	username = serializers.CharField(max_length=32)
	# email = serializers.CharField(style={'input_type': 'email'})
