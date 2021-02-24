from django.urls import path
from . import views

app_name = 'matchmaker'

urlpatterns = [
    path('playeraccounts/',
    	views.PlayerAccountListView.as_view(),
    	name='player_account_list'),
	
	path('playeraccounts/<pk>/',
		views.PlayerAccountDetailView.as_view(),
		name='player_account_detail'),
]