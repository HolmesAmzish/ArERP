CREATE PROCEDURE Update_Employee
    @EmployeeId INT,
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
    UPDATE Employees SET
        EmployeeName = @EmployeeName,
        Gender = @Gender,
        BirthDate = @BirthDate,
        Email = @Email,
        Phone = @Phone,
        HireDate = @HireDate,
        Department = @Department,
        Position = @Position,
        Salary = @Salary,
        IsActive = @IsActive
    WHERE EmployeeId = @EmployeeId
END
