# MediClipWebAPI
MediClip RESTful Web API

## Instructions

The API URL is https://mediclipwebapi.azurewebsites.net/

### Note
* To get all notes associated with the patient use `GetPatientNotes?id={id}` where `{id}` is the PatientID
* To get a specific note for a patient use `GetNote?nId={nId}&pId={pId}`
where `{nId}` is the NoteID and `{pId}` is the PatientID
* To use POST to save a new note to the SQL server use `SaveNote`
* The JSON format for SaveNote is:
```json
{
  "NoteID": 1,
  "PatientID": 2,
  "Title": "sample string 3",
  "Text": "sample string 4",
  "Picture": "sample string 5"
}
```
### Ward
* To get all the wards use `GetAllWards`
* To get a single ward by WardID `GetWard?id={id}` where `{id}` is the WardID
### Patient
* To get all the patients use `GetAllPatients`
* To get all the patients in a specific ward use `GetWardPatients?id={id}` where `{id}` is the WardID
* To get a specific patient using their patient ID and assigned ward use `GetPatient?wId={wId}&pId={pId}`
where `{wId}` is WardID and `{pId}` is PatientID
## Documentation
* mediclipdb.sql - script file necessary for creating the MediClip SQL database

## Tools
Chrome extension used to test POST and GET JSON requests:
* [Servistate HTTP Editor & REST API Client](https://chrome.google.com/webstore/detail/servistate-http-editor-re/mmdjghedkfbdhbjhmefbbgjaihmmhkeg)

## Online Resources
* [Create and Connect a ASP.NET Website, Web API Service, and SQL Database ALL IN ONE VIDEO](https://www.youtube.com/watch?v=ddXVMdeA5D0)
* [Web API to return result from SQL Database](https://stackoverflow.com/questions/41965076/web-api-to-return-result-from-sql-database)
