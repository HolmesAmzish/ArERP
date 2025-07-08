CREATE PROCEDURE Insert_Employee
    @EmployeeName NVARCHAR(100),
    @Gender NVARCHAR(10),
    @BirthDate DATE,
    @Email NVARCHAR(255),
    @Phone NVARCHAR(50),
    @HireDate DATE,
    @Department NVARCHAR(100),
    @Position NVARCHAR(100),
    @Salary DECIMAL(18,2),
    @IsActive BIT
AS
BEGIN
    INSERT INTO Employees (EmployeeName, Gender, BirthDate, Email, Phone, HireDate, Department, Position, Salary, IsActive)
    VALUES (@EmployeeName, @Gender, @BirthDate, @Email, @Phone, @HireDate, @Department, @Position, @Salary, @IsActive)
END