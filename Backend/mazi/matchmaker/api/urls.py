from django.urls import path
from rest_framework.authtoken.views import obtain_auth_token

from . import views


app_name = 'matchmaker'

urlpatterns = [
    path('accounts/signup', views.SignUpView.as_view(), name='signup'),
    path('api-token-auth/', obtain_auth_token, name='api_token_auth'),
]
