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