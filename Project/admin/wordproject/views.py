from django.http import Http404
from wordproject.models import WordRecord
from rest_framework import status
from rest_framework.response import Response
from wordproject.serializers import WordRecordSerializer
from rest_framework.views import APIView
from rest_framework import generics
from datetime import date

class WordRecordList(APIView):
	def get(self, request, format=None):
		wordRecords = WordRecord.objects.all()
		serializer = WordRecordSerializer(wordRecords, many=True)
		return Response(serializer.data)
		
class WordRecordDetail(APIView):
	def get_object(self,pk):
		try:
			return WordRecord.objects.get(pk=pk)
		except WordRecord.DoesNotExist:
			raise Http404
			
	def get(self, request, pk, format=None):
		wordRecord = self.get_object(pk)
		serializer = WordRecordSerializer(wordRecord)
		return Response(serializer.data)
		
class WordRecordFilteredList(generics.ListAPIView):
	serializer_class = WordRecordSerializer
	
	def get_queryset(self):
		"""self.kwargs gets the field from the url"""
		ew = self.kwargs['englishWord']
		querySet = WordRecord.objects.filter(englishWord = ew)
		return querySet
		
class WordRecordQueryParamList(generics.ListAPIView):
	serializer_class = WordRecordSerializer
	
	#user must supply the last sync date
	def get_queryset(self):
		"""pulling terms out from the query parameters"""
		searchYear = self.request.query_params.get('afterYear', None)
		#if no year param provided, return 404
		if searchYear is None:
			raise Http404
		
		searchMonth = self.request.query_params.get('afterMonth', None)
		#if no month param provided, default to January
		if searchMonth is None:
			searchMonth = 1
		
		searchDate = self.request.query_params.get('afterDate', None)
		#if no Date param provided, default to 1st of the month
		if searchDate is None:
			searchDate = 1
		
		userSearchDate = date(int(searchYear),int(searchMonth),int(searchDate))
		
		querySet = WordRecord.objects.filter(dateUpdated__gt = userSearchDate)
		return querySet