from rest_framework import generics
from ..models import PlayerAccount
from .serializers import PlayerAccountSerializer


class PlayerAccountListView(generics.ListAPIView):
	queryset = PlayerAccount.objects.all()
	serializer_class = PlayerAccountSerializer


class PlayerAccountDetailView(generics.RetrieveAPIView):
	queryset = PlayerAccount.objects.all()
	serializer_class = PlayerAccountSerializer
