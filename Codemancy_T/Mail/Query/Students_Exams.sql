USE CodemancyT;

CREATE TABLE Student  
(  
StudentId Integer NOT NULL PRIMARY KEY,  
FirstName Varchar(200) NOT NULL,  
LastName Varchar(200) NOT NULL  
);  

CREATE TABLE Exam  
(  
Name Varchar(255) NOT NULL PRIMARY KEY,  
Points Integer NOT NULL /*ECTS (not specified in task)*/
);  

CREATE TABLE Taken  
(  
	StudentId Integer  NOT NULL FOREIGN KEY REFERENCES Student(StudentId),  
	ExamName Varchar(255) NOT NULL FOREIGN KEY REFERENCES Exam(Name),  
	
	CONSTRAINT PK_TAKEN PRIMARY KEY(StudentId, ExamName)
);  

INSERT INTO Student (StudentId, FirstName, LastName)
VALUES (1, 'Lazar', 'Djodjevic');

INSERT INTO Student (StudentId, FirstName, LastName)
VALUES (2, 'John', 'Doe');

INSERT INTO Student (StudentId, FirstName, LastName)
VALUES (3, 'Jane', 'Doe');

INSERT INTO Student (StudentId, FirstName, LastName)
VALUES (4, 'Petar', 'Peric');

INSERT INTO Student (StudentId, FirstName, LastName)
VALUES (5, 'Marko', 'Markovic');

INSERT INTO Exam (Name, Points)
VALUES ('PS', 6);

INSERT INTO Exam (Name, Points)
VALUES ('SP', 6);

INSERT INTO Exam (Name, Points)
VALUES ('PK', 3);

INSERT INTO Exam (Name, Points)
VALUES ('RG', 5);

INSERT INTO Exam (Name, Points)
VALUES ('SWE', 5);

INSERT INTO Taken(StudentId, ExamName)
VALUES (1, 'RG');

INSERT INTO Taken(StudentId, ExamName)
VALUES (1, 'SWE');

INSERT INTO Taken(StudentId, ExamName)
VALUES (2, 'SWE');

INSERT INTO Taken(StudentId, ExamName)
VALUES (2, 'SP');

INSERT INTO Taken(StudentId, ExamName)
VALUES (2, 'PS');

INSERT INTO Taken(StudentId, ExamName)
VALUES (5, 'PK');

INSERT INTO Taken(StudentId, ExamName)
VALUES (5, 'PS');

INSERT INTO Taken(StudentId, ExamName)
VALUES (5, 'SWE');

/*All students on exam*/
SELECT Student.FirstName, Student.LastName, Student.StudentId
FROM Student INNER JOIN Taken ON Student.StudentId = Taken.StudentId
WHERE Taken.ExamName = 'SWE';

/*All exams of students*/
SELECT Exam.Name, Exam.Points
FROM Exam INNER JOIN Taken ON Exam.Name = Taken.ExamName
WHERE Taken.StudentId = 1;