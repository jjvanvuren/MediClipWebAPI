# MediClipWebAPI
MediClip RESTful Web API by by Francois Janse van Vuren, Karl Foley and Jacobus Janse van Vuren

### Note:
This GitHub repository does **NOT** include an open-source license. This is intentional.  
To find out more about what this means follow the link below:<br>
https://choosealicense.com/no-permission/

## Instructions

The API URL is https://mediclipwebapi.azurewebsites.net/

### Note
* To get all notes associated with the patient use `GetPatientNotes?id={id}` where `{id}` is the PatientID
* To get a specific note for a patient use `GetNote?nId={nId}&pId={pId}` <br />
  where `{nId}` is the NoteID and `{pId}` is the PatientID
* To use POST to save a new note to the SQL server use `SaveNote`
* The JSON format for SaveNote is:
```json
{
  "PatientID": 1,
  "Title": "sample string 2",
  "Text": "sample string 3",
  "Picture": "picture.jpg"
}
```
### Ward
* To get all the wards use `GetAllWards`
* To get a single ward by WardID `GetWard?id={id}` where `{id}` is the WardID
### Patient
* To get all the patients use `GetAllPatients`
* To get all the patients in a specific ward use `GetWardPatients?id={id}` where `{id}` is the WardID
* To get a specific patient using their patient ID and assigned ward use `GetPatient?wId={wId}&pId={pId}` <br />
where `{wId}` is WardID and `{pId}` is PatientID
### Nurse
* To get all the Nurses use `GetAllNurses`
* To get a single nurse from the database by username use `GetNurse?uname={uname}` where `{uname}` is the nurses username
## Documentation
* mediclipdb.sql - script file necessary for creating the MediClip SQL database

## Tools
Chrome extension used to test POST and GET JSON requests:
* [Servistate HTTP Editor & REST API Client](https://chrome.google.com/webstore/detail/servistate-http-editor-re/mmdjghedkfbdhbjhmefbbgjaihmmhkeg)

## Online Resources
* [Create and Connect a ASP.NET Website, Web API Service, and SQL Database ALL IN ONE VIDEO](https://www.youtube.com/watch?v=ddXVMdeA5D0)
* [Web API to return result from SQL Database](https://stackoverflow.com/questions/41965076/web-api-to-return-result-from-sql-database)
