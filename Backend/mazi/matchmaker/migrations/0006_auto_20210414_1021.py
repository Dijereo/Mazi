# Generated by Django 3.0 on 2021-04-14 14:21

from django.db import migrations


class Migration(migrations.Migration):

    dependencies = [
        ('matchmaker', '0005_auto_20210414_0059'),
    ]

    operations = [
        migrations.RenameField(
            model_name='cardowned',
            old_name='cardid',
            new_name='cardenum',
        ),
    ]
