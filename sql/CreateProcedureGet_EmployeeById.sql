CREATE PROCEDURE Get_EmployeeById
    @EmployeeId INT
AS
BEGIN
    SELECT * FROM Employees WHERE EmployeeId = @EmployeeId
END
