using Aerospike.Client;
using AerospikeProtobufExample.Generated;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;

class Program {
    static void Main(string[] args)
    {

        #region MyRegion
        //// creating an instance of Employee
        //Employee employee = new Employee() { Id = 1, FullName = "john smith", Email = "johnsmith@gmail.com" };

        ////store bytes
        //byte[] employeeBytes;

        //// Write to a stream
        //using (MemoryStream stream = new MemoryStream())
        //{
        //    employee.WriteTo(stream);
        //    employeeBytes = stream.ToArray();
        //}
        //// Read from a stream bytes
        //var data = Employee.Parser.ParseFrom(employeeBytes);

        //Console.WriteLine(data);
        //// Write to a file
        //using (Stream output = File.OpenWrite("mydata.data"))
        //{
        //    employee.WriteTo(output);
        //}

        //// Read from a data file
        //using (Stream output = File.OpenRead("mydata.data"))
        //{
        //    var employeeFromFile = Employee.Parser.ParseFrom(output);
        //    Console.WriteLine(employeeFromFile);
        //} 
        #endregion

        #region MyRegion
        //// creating an instance of Employee
        //Meeting meeting = new Meeting() { Subject = "ProtoBuf", Start = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow), Duration = Duration.FromTimeSpan(new TimeSpan(0,1,30,0)) };

        ////store bytes
        //byte[] meetingBytes;

        //// Write to a stream
        //using (MemoryStream stream = new MemoryStream())
        //{
        //    meeting.WriteTo(stream);
        //    meetingBytes = stream.ToArray();
        //}
        //// Read from a stream bytes
        //var data = Meeting.Parser.ParseFrom(meetingBytes);

        //Console.WriteLine(data);
        //// Write to a file
        //using (Stream output = File.OpenWrite("mydata.data"))
        //{
        //    meeting.WriteTo(output);
        //}

        ////Read from a data file
        //using (Stream output = File.OpenRead("mydata.data"))
        //{
        //    var meetingFromFile = Meeting.Parser.ParseFrom(output);
        //    Console.WriteLine(meetingFromFile);
        //}

        //var memory = meeting.ToByteArray();
        //Console.WriteLine($"memory length: {memory.Length}");
        //var disk = File.ReadAllBytes("mydata.data");
        //Console.WriteLine($"disk length: {disk.Length}");
        //Console.WriteLine(Meeting.Parser.ParseFrom(disk)); 
        #endregion

        var user = new UserRecord
        {
            UserId = "user123",
            UserName = "John Doe",
            LoginCount = 5,
            ProfilePicture = ByteString.CopyFrom(new byte[] { 0x01, 0x02, 0x03 }) // Dummy byte array
        };

        Program program = new Program();
        // Store the Protobuf object in Aerospike
        program.StoreUser(user);

        // Retrieve the object and display details
        UserRecord retrievedUser = program.RetrieveUser("user123");
        Console.WriteLine($"Retrieved User: {retrievedUser.UserName}, Logins: {retrievedUser.LoginCount}");

    }

    private AerospikeClient client;

    public Program()
    {
        // Replace with your Aerospike server's IP address and port
        client = new AerospikeClient("127.0.0.1", 3000);
    }

    private void StoreUser(UserRecord user)
    {
        // Serialize the Protobuf message to a byte array
        byte[] data = user.ToByteArray();

        // Define the Aerospike key
        Key key = new Key("test", "users", user.UserId);

        // Create a Bin to store the byte array
        Bin bin = new Bin("userData", data);

        // Write the record to Aerospike
        client.Put(null, key, bin);
        Console.WriteLine("User record stored in Aerospike.");
    }

    private UserRecord RetrieveUser(string userId)
    {
        Key key = new Key("test", "users", userId);
        Record record = client.Get(null, key);

        if (record != null)
        {
            // Retrieve the byte array from the Bin
            byte[] data = record.GetValue("userData") as byte[];

            // Deserialize the byte array back into a Protobuf object
            return UserRecord.Parser.ParseFrom(data);
        }

        return null;
    }
}