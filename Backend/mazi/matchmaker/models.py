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
	created = models.DateTimeField(auto_now_add=True)
	player = models.ForeignKey(User, on_delete=models.CASCADE, related_name='account')
	gamesplayed = models.IntegerField(default=0)
	wins = models.IntegerField(default=0)
	losses = models.IntegerField(default=0)
	rating = models.IntegerField(default=500)
	ranking = models.CharField(max_length=20, choices=RANKINGS, default='unranked')

	def __str__(self):
		return f'{self.player} {self.ranking}'


class Deck(models.Model):
	owner = models.ForeignKey(PlayerAccount, on_delete=models.CASCADE, related_name='decks')
	deckname = models.CharField(max_length=25)

	def __str__(self):
		return self.deckname


class CardOwned(models.Model):
	owner = models.ForeignKey(PlayerAccount, on_delete=models.CASCADE, related_name='cards')
	cardenum = models.IntegerField()


class CardInstance(models.Model):
	deck = models.ForeignKey(Deck, on_delete=models.CASCADE, related_name='cards')
	card = models.ForeignKey(CardOwned, on_delete=models.CASCADE, related_name='instances')


class Match(models.Model):
	STATES = (
		('ongoing', 'Ongoing'),
		('aborted', 'Aborted'),
		('finished', 'Finished')
	)
	starttime = models.DateTimeField(auto_now_add=True)
	player1 = models.ForeignKey(PlayerAccount, on_delete=models.SET_NULL, blank=True, null=True, related_name='matches_hosted')
	player2 = models.ForeignKey(PlayerAccount, on_delete=models.SET_NULL, blank=True, null=True, related_name='matches_joined')
	winner = models.ForeignKey(PlayerAccount, on_delete=models.SET_NULL, blank=True, null=True, related_name='matches_won')
	loser = models.ForeignKey(PlayerAccount, on_delete=models.SET_NULL, blank=True, null=True, related_name='matches_lost')
	status = models.CharField(max_length=20, choices=STATES, default='ongoing')
