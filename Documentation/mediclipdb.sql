--Create the Nurse Table
CREATE TABLE Nurse (
	NurseID						INT				PRIMARY KEY CHECK (NurseID > 0 AND NurseID <= 9999),
	FirstName					VARCHAR(15)		NOT NULL,
	LastName					VARCHAR(15)		NOT NULL,
	Password					VARCHAR(30)		NOT NULL
)

--Create the Ward table
CREATE TABLE Ward (
	WardID						INT				PRIMARY KEY CHECK (WardID > 0 AND WardID <= 9999),
	WardTitle					VARCHAR(15)		NOT NULL,\
	Location					VARCHAR(15)		NOT NULL,
	Description					VARCHAR(150)	NOT NULL
)

--Create the Patient table
CREATE TABLE Patient (
	PatientID					INT				PRIMARY KEY CHECK (PatientID > 0 AND PatientID <= 9999),
	WardID						INT				CHECK (WardID > 0 AND WardID <= 9999),
	AssignDateFrom				DATE			NOT NULL,
	AssignDateTo				DATE			NOT NULL,
	FirstName					VARCHAR(15)		NOT NULL,
	LastName					VARCHAR(15)		NOT NULL,
	Dob							DATE			NOT NULL,
	Sex							VARCHAR(7)		NOT NULL,
	Dosage						VARCHAR(150)	NOT NULL,
	BedNumber					INT(2)			CHECK (BedNumber > 0 AND WardID <= 30),
	FOREIGN KEY(WardID)		REFERENCES	Ward (WardID) ON UPDATE CASCADE ON DELETE CASCADE
)

--Create the AssignedWard table
CREATE TABLE AssignedWard (
	NurseID						INT				NOT NULL CHECK (NurseID > 0 AND NurseID <= 9999),
	WardID						INT				NOT NULL CHECK (WardID > 0 AND WardID <= 9999),
	AssignDateFrom				DATE			NOT NULL,
	AssignDateTo				DATE			NOT NULL,
	PRIMARY KEY (NurseID, WardID),
	FOREIGN KEY(NurseID)		REFERENCES Nurse (NurseID)	ON UPDATE CASCADE ON DELETE NO ACTION,
	FOREIGN KEY(WardID)			REFERENCES Ward (WardID)	ON UPDATE CASCADE ON DELETE NO ACTION,
)

--Creating the Notes Table
CREATE TABLE Notes(
	NoteID						INT 			NOT NULL CHECK (NoteID > 0 AND NoteID <= 9999),
	PatientID					INT				NOT NULL CHECK (WardID > 0 AND WardID <= 9999),
	NoteTitle					VARCHAR(50)		NOT NULL,
	Note						VARCHAR(500)	NOT NULL,
	Picture						VARCHAR(100)	NOT NULL,
	PRIMARY KEY (NoteID, PatientID),
	FOREIGN KEY(PatientID)		REFERENCES Patient (PatientID)	ON UPDATE CASCADE ON DELETE CASCADE,
)
