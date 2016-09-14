from django.contrib import admin

from .models import WordRecord


class WordAdmin(admin.ModelAdmin):
    list_display = ['englishWord', 'maoriWord', 'description', 'year', 'month', 'dateCreated', 'dateUpdated', 'publish']

admin.site.register(WordRecord, WordAdmin)
