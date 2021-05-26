CREATE TABLE Position
(
  Name INT NOT NULL,
  Salary INT NOT NULL,
  Responsibility INT NOT NULL,
  Requirement INT NOT NULL,
  PositionKey INT NOT NULL,
  PRIMARY KEY (PositionKey)
);

CREATE TABLE Brand
(
  Name INT NOT NULL,
  Specifications INT NOT NULL,
  Cost INT NOT NULL,
  Specificity INT NOT NULL,
  BrandKey INT NOT NULL,
  PRIMARY KEY (BrandKey)
);

CREATE TABLE Rate
(
  RateKey INT NOT NULL,
  Name INT NOT NULL,
  Description INT NOT NULL,
  Cost INT NOT NULL,
  PRIMARY KEY (RateKey)
);

CREATE TABLE AddService
(
  AddServiceKey INT NOT NULL,
  Name INT NOT NULL,
  Description INT NOT NULL,
  Cost INT NOT NULL,
  PRIMARY KEY (AddServiceKey)
);

CREATE TABLE Employee
(
  EmployeeKey INT NOT NULL,
  FullName INT NOT NULL,
  DateOfBirth INT NOT NULL,
  Gender INT NOT NULL,
  Address INT NOT NULL,
  Number INT NOT NULL,
  Passport INT NOT NULL,
  PositionKey INT NOT NULL,
  PRIMARY KEY (EmployeeKey),
  FOREIGN KEY (PositionKey) REFERENCES Position(PositionKey)
);

CREATE TABLE Car
(
  CarKey INT NOT NULL,
  RegistrationNumber INT NOT NULL,
  BodNumber INT NOT NULL,
  EngineNumber INT NOT NULL,
  YearOfIssue INT NOT NULL,
  Mileage INT NOT NULL,
  MaintenanceDate INT NOT NULL,
  SpecialMarks INT NOT NULL,
  EmployeeKey INT NOT NULL,
  BrandKey INT NOT NULL,
  MechanicKeyEmployeeKey INT NOT NULL,
  PRIMARY KEY (CarKey),
  FOREIGN KEY (EmployeeKey) REFERENCES Employee(EmployeeKey),
  FOREIGN KEY (BrandKey) REFERENCES Brand(BrandKey),
  FOREIGN KEY (MechanicKeyEmployeeKey) REFERENCES Employee(EmployeeKey)
);

CREATE TABLE Call
(
  Date INT NOT NULL,
  Time INT NOT NULL,
  Number INT NOT NULL,
  WhereFrom INT NOT NULL,
  WhereTo INT NOT NULL,
  CarKey INT NOT NULL,
  EmployeeKey INT NOT NULL,
  RateKey INT NOT NULL,
  AddServiceKey INT NOT NULL,
  FOREIGN KEY (CarKey) REFERENCES Car(CarKey),
  FOREIGN KEY (EmployeeKey) REFERENCES Employee(EmployeeKey),
  FOREIGN KEY (RateKey) REFERENCES Rate(RateKey),
  FOREIGN KEY (AddServiceKey) REFERENCES AddService(AddServiceKey)
);