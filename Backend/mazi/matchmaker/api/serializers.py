from rest_framework import serializers
from ..models import PlayerAccount


class PlayerAccountSerializer(serializers.ModelSerializer):
	class Meta:
		model = PlayerAccount
		fields = ['username', 'rating']
