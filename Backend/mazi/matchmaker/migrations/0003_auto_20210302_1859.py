# Generated by Django 3.0 on 2021-03-02 22:59

from django.db import migrations, models
import django.db.models.deletion


class Migration(migrations.Migration):

    dependencies = [
        ('matchmaker', '0002_cardinstance_deck_match'),
    ]

    operations = [
        migrations.RemoveField(
            model_name='cardinstance',
            name='cardid',
        ),
        migrations.CreateModel(
            name='CardOwned',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('cardid', models.IntegerField()),
                ('owner', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, related_name='cards', to='matchmaker.PlayerAccount')),
            ],
        ),
        migrations.AddField(
            model_name='cardinstance',
            name='card',
            field=models.ForeignKey(default=0, on_delete=django.db.models.deletion.CASCADE, related_name='instances', to='matchmaker.CardOwned'),
            preserve_default=False,
        ),
    ]
