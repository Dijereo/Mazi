from django.contrib.auth import authenticate, login
from django.contrib.auth.models import User, UserManager
from django.shortcuts import get_object_or_404
from rest_framework import generics, status
from rest_framework.views import APIView
from rest_framework.response import Response
from rest_framework.authtoken.models import Token

from ..models import *
from .serializers import *


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
