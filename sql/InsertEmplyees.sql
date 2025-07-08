EXEC Insert_Employee 
    @EmployeeName = N'John Doe',
    @Gender = N'Male',
    @BirthDate = '1990-01-01',
    @Email = N'john.doe@example.com',
    @Phone = N'1234567890',
    @HireDate = '2020-06-15',
    @Department = N'Sales',
    @Position = N'Sales Manager',
    @Salary = 65000.00,
    @IsActive = 1;

EXEC Insert_Employee 
    @EmployeeName = N'Jane Smith',
    @Gender = N'Female',
    @BirthDate = '1985-05-10',
    @Email = N'jane.smith@example.com',
    @Phone = N'0987654321',
    @HireDate = '2018-09-01',
    @Department = N'Marketing',
    @Position = N'Marketing Director',
    @Salary = 85000.00,
    @IsActive = 1;