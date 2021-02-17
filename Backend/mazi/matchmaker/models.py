from django.db import models
from django.utils import timezone
from django.contrib.auth.models import User

class PlayerAccount(models.Model):
	RANKINGS = (
		('unranked', 'Unranked'),
		('bronze', 'Bronze'),
		('silver', 'Silver'),
		('gold', 'Gold')
	)
	username = models.CharField(max_length=25)
	created = models.DateTimeField(auto_now_add=True)
	player = models.ForeignKey(User, on_delete=models.CASCADE, related_name='account')
	gamesplayed = models.IntegerField(default=0)
	wins = models.IntegerField(default=0)
	losses = models.IntegerField(default=0)
	rating = models.IntegerField(default=500)
	ranking = models.CharField(max_length=20, choices=RANKINGS, default='unranked')

	def __str__(self):
		return self.username

