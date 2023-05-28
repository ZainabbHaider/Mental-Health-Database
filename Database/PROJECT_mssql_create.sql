CREATE TABLE [Patient] (
	ID varchar(255) NOT NULL,
	Name varchar(255) NOT NULL,
	Age integer NOT NULL,
	Gender varchar(255) NOT NULL,
	Username varchar(255) NOT NULL,
	Password varchar(255) NOT NULL,
  CONSTRAINT [PK_PATIENT] PRIMARY KEY CLUSTERED
  (
  [ID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Medical_Professionals] (
	ID varchar(255) NOT NULL,
	Name varchar(255) NOT NULL,
	Age integer NOT NULL,
	Gender varchar(255) NOT NULL,
	Specialisation varchar(255) NOT NULL,
	ClinicID varchar(255) NOT NULL,
	Fees decimal NOT NULL,
	Username varchar(255) NOT NULL,
	Password varchar(255) NOT NULL,
  CONSTRAINT [PK_MEDICAL_PROFESSIONALS] PRIMARY KEY CLUSTERED
  (
  [ID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Appointments] (
	ID integer NOT NULL,
	Date datetime NOT NULL,
	Location varchar(255) NOT NULL,
	PatientID varchar(255) NOT NULL,
	ModeOfTreatment integer NOT NULL,
	ScheduleID integer NOT NULL,
	Status varchar(255) NOT NULL,
  CONSTRAINT [PK_APPOINTMENTS] PRIMARY KEY CLUSTERED
  (
  [ID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Admin] (
	ID varchar(255) NOT NULL,
	Name varchar(255) NOT NULL,
  CONSTRAINT [PK_ADMIN] PRIMARY KEY CLUSTERED
  (
  [ID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Illness] (
	Name varchar(255) NOT NULL,
	Symptoms varchar(255) NOT NULL,
  CONSTRAINT [PK_ILLNESS] PRIMARY KEY CLUSTERED
  (
  [Name] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Payment_Details] (
	ID varchar(255) NOT NULL,
	PayementMethod varchar(255) NOT NULL,
	ReceiptID integer NOT NULL,
	Fees decimal NOT NULL,
  CONSTRAINT [PK_PAYMENT_DETAILS] PRIMARY KEY CLUSTERED
  (
  [ID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Symptoms] (
	SymptomName varchar(255) NOT NULL,
  CONSTRAINT [PK_SYMPTOMS] PRIMARY KEY CLUSTERED
  (
  [SymptomName] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Ilness_to_Symptoms] (
	IllnessName varchar(255) NOT NULL,
	SymptomName varchar(255) NOT NULL,
  CONSTRAINT [PK_ILNESS_TO_SYMPTOMS] PRIMARY KEY CLUSTERED
  (
  [IllnessName] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Schedule] (
	ID integer NOT NULL,
	MedicalProfessionalID varchar(255) NOT NULL,
	TimeSlot1 varchar(255) NOT NULL,
	TimeSlot2 varchar(255) NOT NULL,
  CONSTRAINT [PK_SCHEDULE] PRIMARY KEY CLUSTERED
  (
  [ID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Patient_Diagnosis] (
	DiagnosisID integer NOT NULL,
	PatientID varchar(255) NOT NULL,
	Medical_History varchar(255) NOT NULL,
  CONSTRAINT [PK_PATIENT_DIAGNOSIS] PRIMARY KEY CLUSTERED
  (
  [DiagnosisID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Clinic] (
	ClinicID varchar(255) NOT NULL,
	ClinicName varchar(255) NOT NULL,
	ClinicLocation varchar(255) NOT NULL,
  CONSTRAINT [PK_CLINIC] PRIMARY KEY CLUSTERED
  (
  [ClinicID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Patient_Diagnosis_to_Symptoms] (
	DiagnosisID integer NOT NULL,
	SymptomName varchar(255) NOT NULL,
  CONSTRAINT [PK_PATIENT_DIAGNOSIS_TO_SYMPTOMS] PRIMARY KEY CLUSTERED
  (
  [DiagnosisID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO

ALTER TABLE [Medical_Professionals] WITH CHECK ADD CONSTRAINT [Medical_Professionals_fk0] FOREIGN KEY ([ClinicID]) REFERENCES [Clinic]([ClinicID])
ON UPDATE CASCADE
GO
ALTER TABLE [Medical_Professionals] CHECK CONSTRAINT [Medical_Professionals_fk0]
GO

ALTER TABLE [Appointments] WITH CHECK ADD CONSTRAINT [Appointments_fk0] FOREIGN KEY ([PatientID]) REFERENCES [Patient]([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [Appointments] CHECK CONSTRAINT [Appointments_fk0]
GO
ALTER TABLE [Appointments] WITH CHECK ADD CONSTRAINT [Appointments_fk1] FOREIGN KEY ([ScheduleID]) REFERENCES [Schedule]([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [Appointments] CHECK CONSTRAINT [Appointments_fk1]
GO





ALTER TABLE [Ilness_to_Symptoms] WITH CHECK ADD CONSTRAINT [Ilness_to_Symptoms_fk0] FOREIGN KEY ([IllnessName]) REFERENCES [Illness]([Name])
ON UPDATE CASCADE
GO
ALTER TABLE [Ilness_to_Symptoms] CHECK CONSTRAINT [Ilness_to_Symptoms_fk0]
GO
ALTER TABLE [Ilness_to_Symptoms] WITH CHECK ADD CONSTRAINT [Ilness_to_Symptoms_fk1] FOREIGN KEY ([SymptomName]) REFERENCES [Symptoms]([SymptomName])
ON UPDATE CASCADE
GO
ALTER TABLE [Ilness_to_Symptoms] CHECK CONSTRAINT [Ilness_to_Symptoms_fk1]
GO

ALTER TABLE [Schedule] WITH CHECK ADD CONSTRAINT [Schedule_fk0] FOREIGN KEY ([MedicalProfessionalID]) REFERENCES [Medical_Professionals]([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [Schedule] CHECK CONSTRAINT [Schedule_fk0]
GO

ALTER TABLE [Patient_Diagnosis] WITH CHECK ADD CONSTRAINT [Patient_Diagnosis_fk0] FOREIGN KEY ([PatientID]) REFERENCES [Patient]([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [Patient_Diagnosis] CHECK CONSTRAINT [Patient_Diagnosis_fk0]
GO


ALTER TABLE [Patient_Diagnosis_to_Symptoms] WITH CHECK ADD CONSTRAINT [Patient_Diagnosis_to_Symptoms_fk0] FOREIGN KEY ([DiagnosisID]) REFERENCES [Patient_Diagnosis]([DiagnosisID])
ON UPDATE CASCADE
GO
ALTER TABLE [Patient_Diagnosis_to_Symptoms] CHECK CONSTRAINT [Patient_Diagnosis_to_Symptoms_fk0]
GO
ALTER TABLE [Patient_Diagnosis_to_Symptoms] WITH CHECK ADD CONSTRAINT [Patient_Diagnosis_to_Symptoms_fk1] FOREIGN KEY ([SymptomName]) REFERENCES [Symptoms]([SymptomName])
ON UPDATE CASCADE
GO
ALTER TABLE [Patient_Diagnosis_to_Symptoms] CHECK CONSTRAINT [Patient_Diagnosis_to_Symptoms_fk1]
GO

