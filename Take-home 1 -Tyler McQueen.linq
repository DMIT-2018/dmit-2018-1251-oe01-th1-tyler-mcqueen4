<Query Kind="Statements">
  <Connection>
    <ID>bee0edd0-017d-49fe-9408-ade6034405d4</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>StartTed-2025-Sept</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
</Query>

//Q1
ClubActivities.Where(ca => ca.StartDate.Value >= new DateTime(2025, 01, 01) && ca.CampusVenue.Location != "Scheduled Room" && ca.Name != "BTech Club Meeting")
	.Select(ca => new
	{
		StartDate = ca.StartDate.Value,
		Location = ca.CampusVenue.Location,
		Club = ca.Club.ClubName,
		Activity = ca.Name
	})
		.OrderBy(ca => ca.StartDate)
		.Dump();

//Q2
Programs.Select(p => new
{
	School = p.SchoolCode == "SAMIT" ? "School of Advanced Media and IT"
							  : p.SchoolCode == "SEET" ? "School of Electrical Engineering Technology"
							  : "Unknown",
	Program = p.ProgramName,
	RequiredCourseCount = p.ProgramCourses.Count(pc => pc.Required),
	OptionalCourseCount = p.ProgramCourses.Count(pc => !pc.Required)
})
	.Where(p => p.RequiredCourseCount >= 22)
	.OrderBy(p => p.Program)
	.Dump();

//Q3
Students.Where(s => s.Countries.CountryName != "Canada" && !s.StudentPayments.Any())
	.OrderBy(s => s.LastName)
	.Select(s => new
	{
		StudentNumber = s.StudentNumber,
		CountryName = s.Countries.CountryName,
		FullName = $"{s.FirstName} {s.LastName}",
		ClubMembershipCount = s.ClubMembers.Count() == 0 ? "None"
													: s.ClubMembers.Count().ToString()

	})
	.Dump();
//Q4

Employees.Where(e => e.Position.Description == "Instructor" && e.ReleaseDate.Value == null && e.ClassOfferings.Any())
	.OrderByDescending(e => e.ClassOfferings.Count())
	.ThenBy(e => e.LastName)
	.Select(e => new
	{
		ProgramName = e.Program.ProgramName,
		FullName = $"{e.FirstName} {e.LastName}",
		WorkLoad = e.ClassOfferings.Count() > 24 ? "High"
				 : e.ClassOfferings.Count() > 8 ? "Med"
												  : "Low"
	})
	.Dump();
//Q5
Clubs.Select(c => new
{
	Supervisor = c.EmployeeID == null ? "Unknown"
										: c.Employee.FirstName + " " + c.Employee.LastName,
	Club = c.ClubName,
	MemberCount = c.ClubMembers.Count(),
	Activites = c.ClubActivities.Count() == 0 ? "None Schedule"
											: c.ClubActivities.Count().ToString()

})
	.OrderByDescending(c => c.MemberCount)
	.Dump();
