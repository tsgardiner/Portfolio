# -*- coding: utf-8 -*-
# Generated by Django 1.9.4 on 2016-03-30 22:21
from __future__ import unicode_literals

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('wordproject', '0002_auto_20160331_1111'),
    ]

    operations = [
        migrations.AlterField(
            model_name='wordrecord',
            name='description',
            field=models.TextField(blank=True, max_length=200, null=True),
        ),
    ]