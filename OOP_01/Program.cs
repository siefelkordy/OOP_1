

namespace OOP_01
{
    public struct DeliveryAddress
    {
        string City;
        string Street;
        int BuildingNumber;
        public DeliveryAddress(string city, string street ,  int buildingNumber)
        {
            City = city;
            Street = street;
            BuildingNumber = buildingNumber;
        }
        public string GetFullAddress()
        {
            return $"{BuildingNumber} {Street} ,{City}";
        }


    }



    internal struct Shipment
    {
        string trackingCode;
        string description;
        int weight;
        decimal deliveryFee;
        DeliveryAddress destination;

 
       //Properties
       //1.Tracking Code Property
       public string TrackingCode { 
            get
            {
                return trackingCode;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(trackingCode) && trackingCode == string.Empty)
                {
                    trackingCode = value;
                }
                else
                {
                    throw new ArgumentException("Tracking Code can't be null or empty");
                }
            }
        }
        //2.Description Property
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(description) || description == string.Empty)
                {
                    throw new ArgumentException("Description cannot be null or empty.");
                }
                else
                {
                    description = value;
                }
            }
        }
        //3.Weight Property
        public int Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (weight <= 0)
                {
                    throw new ArgumentException("Weight must be a positive number.");
                }
                weight = value;
            }
            
        }
        //4.Delivery Fee Property
        public decimal DeliveryFee
        {
            get
            {
                return deliveryFee;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Delivery fee must be a positive number.");
                }
                else
                {
                    deliveryFee = value;
                }
            }
        }
       //5.Destination Property
       public DeliveryAddress Destination { 
            get
            {
                return destination;
            }
            set
            {
                destination = value;
            }
        }
        public decimal EstimatedCost
        {
            get
            {
                return deliveryFee + (weight * 5);
            }
        }
       
        //////////////Constructors
        //1st Constructor
        public Shipment(string trackingCode)
        {
            this.trackingCode = trackingCode;
            description = "Unknown";
            weight = 1;
            deliveryFee = 50;
            destination = new DeliveryAddress("Nasr city", "Al Nahas", 15);
        }
        //2nd Constructor
        public Shipment(string TrackingCode, string Description, int Weight, decimal DeliveryFee)
        {
            trackingCode = TrackingCode;
            description = Description;
            weight = Weight;
            deliveryFee = DeliveryFee;
        }
        //////////////Methods
        //Update DeliveryFee Method
        public void UpdateDeilveryFee(decimal newFee)
        {
            if (newFee > 0)
            {
                deliveryFee = newFee;
            }
            else
            {
                throw new ArgumentException("Delivery fee must be a positive number.");
            }
        }
        //Print Shipment Method
        public string PrintShipmentDetails()
        {
            return $"Tracking Code: {TrackingCode}, Description: {Description}, Weight: {Weight}kg, Delivery Fee: {deliveryFee}, Estimated Cost: {EstimatedCost} ";
        }
        
        


    }
    //Delivery Center Struct
    public struct DeliveryCenter
    {
        Shipment[] shipment = new Shipment[10];

        public Shipment this[int index]
        {
            get
            {
                if (index>=0 && index < shipment.Length)
                {
                    return shipment[index];
                }
            }
            set
            {
                if (index >= 0 && index < shipment.Length)
                {
                    shipment[index] = value;
                }
            }
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            DeliveryAddress address = new DeliveryAddress("New York", "5th Avenue", 123);
            DeliveryAddress address1 = address;
            Console.WriteLine(address.GetFullAddress());
            Console.WriteLine(address1.GetFullAddress());
        }
    }
}
