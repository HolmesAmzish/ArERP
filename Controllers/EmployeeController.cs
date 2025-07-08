using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System;
using ArERP.Models.Entity;

namespace ArERP.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly string _connectionString;

        public EmployeeController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // GET: /employee/
        [Route("/employee/")]
        public IActionResult Index()
        {
            var employees = new List<EmployeeEntity>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Get_Employees", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employees.Add(new EmployeeEntity
                            {
                                EmployeeId = reader.GetInt32(reader.GetOrdinal("EmployeeId")),
                                EmployeeName = reader.GetString(reader.GetOrdinal("EmployeeName")),
                                Gender = reader.GetString(reader.GetOrdinal("Gender")),
                                BirthDate = reader.IsDBNull(reader.GetOrdinal("BirthDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("BirthDate")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                Phone = reader.GetString(reader.GetOrdinal("Phone")),
                                HireDate = reader.IsDBNull(reader.GetOrdinal("HireDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("HireDate")),
                                Department = reader.GetString(reader.GetOrdinal("Department")),
                                Position = reader.GetString(reader.GetOrdinal("Position")),
                                Salary = reader.IsDBNull(reader.GetOrdinal("Salary")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("Salary")),
                                IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"))
                            });
                        }
                    }
                }
            }

            return Ok(employees);
        }

        // GET: /Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeEntity employee)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("Insert_Employee", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Gender", employee.Gender ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@BirthDate", employee.BirthDate ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Email", employee.Email ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Phone", employee.Phone ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@HireDate", employee.HireDate ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Department", employee.Department ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Position", employee.Position ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Salary", employee.Salary ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@IsActive", employee.IsActive);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: /Employee/Details/5
        public IActionResult Details(int id)
        {
            EmployeeEntity employee = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Get_Employee", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeId", id);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            employee = new EmployeeEntity
                            {
                                EmployeeId = reader.GetInt32(reader.GetOrdinal("EmployeeId")),
                                EmployeeName = reader.GetString(reader.GetOrdinal("EmployeeName")),
                                Gender = reader.GetString(reader.GetOrdinal("Gender")),
                                BirthDate = reader.IsDBNull(reader.GetOrdinal("BirthDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("BirthDate")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                Phone = reader.GetString(reader.GetOrdinal("Phone")),
                                HireDate = reader.IsDBNull(reader.GetOrdinal("HireDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("HireDate")),
                                Department = reader.GetString(reader.GetOrdinal("Department")),
                                Position = reader.GetString(reader.GetOrdinal("Position")),
                                Salary = reader.IsDBNull(reader.GetOrdinal("Salary")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("Salary")),
                                IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"))
                            };
                        }
                    }
                }
            }

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }
    }
}