from django.urls import path
from rest_framework.authtoken.views import obtain_auth_token

from . import views


app_name = 'matchmaker'

urlpatterns = [
    path('accounts/signup/', views.SignUpView.as_view(), name='signup'),
    path('accounts/signin/', views.SignInView.as_view(), name='signin'),
    path('games/search/', views.SearchGameView.as_view(), name='searchgame'),
    path('cards/deck/', views.DeckView.as_view(), name='deck'),
]
