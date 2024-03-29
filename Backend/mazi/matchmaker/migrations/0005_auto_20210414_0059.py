# Generated by Django 3.0 on 2021-04-14 04:59

from django.db import migrations, models
import django.db.models.deletion


class Migration(migrations.Migration):

    dependencies = [
        ('matchmaker', '0004_remove_playeraccount_username'),
    ]

    operations = [
        migrations.AddField(
            model_name='match',
            name='loser',
            field=models.ForeignKey(blank=True, null=True, on_delete=django.db.models.deletion.SET_NULL, related_name='matches_lost', to='matchmaker.PlayerAccount'),
        ),
        migrations.AddField(
            model_name='match',
            name='player1',
            field=models.ForeignKey(blank=True, null=True, on_delete=django.db.models.deletion.SET_NULL, related_name='matches_hosted', to='matchmaker.PlayerAccount'),
        ),
        migrations.AddField(
            model_name='match',
            name='player2',
            field=models.ForeignKey(blank=True, null=True, on_delete=django.db.models.deletion.SET_NULL, related_name='matches_joined', to='matchmaker.PlayerAccount'),
        ),
        migrations.AddField(
            model_name='match',
            name='status',
            field=models.CharField(choices=[('ongoing', 'Ongoing'), ('aborted', 'Aborted'), ('finished', 'Finished')], default='ongoing', max_length=20),
        ),
        migrations.AddField(
            model_name='match',
            name='winner',
            field=models.ForeignKey(blank=True, null=True, on_delete=django.db.models.deletion.SET_NULL, related_name='matches_won', to='matchmaker.PlayerAccount'),
        ),
    ]
