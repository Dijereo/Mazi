from django.contrib import admin
from .models import PlayerAccount, Deck, CardInstance, Match

admin.site.register(PlayerAccount)
admin.site.register(Deck)
admin.site.register(CardInstance)
admin.site.register(Match)
