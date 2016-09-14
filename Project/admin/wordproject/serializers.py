from rest_framework import serializers
from wordproject.models import WordRecord

class WordRecordSerializer(serializers.ModelSerializer):
	class Meta:
		model = WordRecord
		fields = ('maoriWord','englishWord','description','dateCreated','dateUpdated','publish','month','year')