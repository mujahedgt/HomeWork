using Amazon.EC2.Model;
using Amazon.EC2;
using Amazon;

static async void goko()
{

    try
    {

        string IP1 = "", IP2, Ass1 = "", Ass2;
        using (AmazonEC2Client ec2Client = new AmazonEC2Client(RegionEndpoint.USWest2))
        {
            // Make a request to EC2 in the us-west-2 Region using ec2Client

            if (IP1 != "")
            {
                var request1 = new AllocateAddressRequest();

                var response1 = await ec2Client.AllocateAddressAsync(request1);
                IP2 = response1.AllocationId;

                var request2 = new AssociateAddressRequest
                {
                    AllocationId = IP2,
                    InstanceId = "i-0d24b21911b7ec4d5"
                };

                var response2 = await ec2Client.AssociateAddressAsync(request2);
                Ass2 = response2.AssociationId;

                var response3 = await ec2Client.DisassociateAddressAsync(
                        new DisassociateAddressRequest { AssociationId = Ass1 });
                Ass1 = Ass2;

                var request4 = new ReleaseAddressRequest
                {
                    AllocationId = IP1
                };

                var response4 = await ec2Client.ReleaseAddressAsync(request4);

                IP1 = IP2;
            }
            else
            {
                var request1 = new AllocateAddressRequest();

                var response1 = await ec2Client.AllocateAddressAsync(request1);
                IP1 = response1.AllocationId;
                string f = response1.PublicIp;


                Console.ReadLine();

                //var request2 = new AssociateAddressRequest
                //{
                //    AllocationId = IP1,
                //    InstanceId = "i-0d24b21911b7ec4d5"
                //};

                //var response2 = await ec2Client.AssociateAddressAsync(request2);
                //Ass1 = response2.AssociationId;
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

}




goko();



Console.ReadLine();