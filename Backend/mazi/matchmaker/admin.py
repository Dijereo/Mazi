from django.contrib import admin
from .models import PlayerAccount, Deck, CardOwned, CardInstance, Match

admin.site.register(PlayerAccount)
admin.site.register(Deck)
admin.site.register(CardOwned)
admin.site.register(CardInstance)
admin.site.register(Match)
