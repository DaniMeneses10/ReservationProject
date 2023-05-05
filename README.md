# ReservationProject

STRUCTURE
1. I have create 5 Tables in our DB ->
  Users
  Buildings
  Reservations
  Furnitures
  ReservationsFurnitures
  
2. The Architecture of the API has different folders
	a. Contoller: Controllers of the API. In this Case de UserController and ReservationController
	b. Database: Here is saved the DBContext and the DBSets		
	c. Interfaces: You will fin the UserService and ReservationValidator Interfaces
	d. Models: Here you will find the models created for this API
		- Entities : Classes that will work with our DB		
		- Requests: Object that comes from the Frontend
		- Responses: Response from Backend to show if a reservation was created or if it has errors
		- Validators: Will show the errors or validations that the API has.
			NOTE: All these validations could be showed as Exceptions, however for this case I prefered to list all them
	e. Services: Here you will find the logic of the API
		UserService: You will find the CRUD of a user
		ReservatoinService: Here the reservation will be created and it will be validated if it is possible or not
    
3. Config: In the Config we add the connection String of the Local Database and the Dependency Injection to use the DB and the Services

In the folder "AditionalScripts" You will find a SQL Query to create a new DataBase with all tables and Seed in the required tables.
In addition you will find a file from Postman. You will be able to import it from Postman and run through POST and the URL
Example: https://localhost:44357/api/Reservation/CreateReservation


Users
	UserID
	Name
	Email
	Cellphone
	Type
		Person
		Company
	DateBirth
	UserStatus
		Available
		Due
		Canceled
	isHost
		yes
		no
		

Buildings
	BuildingID
	OwnerID
	Address
	Description 
	Capacity (number of persons)
	HourlyRate(RentalPrice)
	
	
Reservation
	ReservationID
	BuildingID			
	ClientID	
	Date
	StartTime
	EndTime
	TotalPrice
	EventType
		Birthdays
		Weddings
		Conferences
		Trainings
	TotalHours
	
	
Furtniture
	FurnitureID
	Available
		Yes
		No
	Description		
		Tables
		Chair
		Music
	HourlyRate(RentalPrice)
	
		
ReservationFurniture
	ReservationFurnitureID
	ReservationID
	FurtnitureID
	


	
	



