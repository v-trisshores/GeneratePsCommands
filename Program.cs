using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static readonly string OutputPath = @"C:\Users\<username>\Desktop\receive-connector-command.txt";

        static void Main()
        {
            int counter = 0;
            int max = 1250;
            StringBuilder sb = new();
            sb.Append("Set-ReceiveConnector -Identity \"Internet Receive Connector1\" -RemoteIPRanges ");
            //sb.Append("New-ReceiveConnector -Name \"Internet Receive Connector2\" -Usage Internet -Bindings 10.10.1.5:26 -RemoteIPRanges ");

            for (int i = 1; i < 255; i++)
            {
                for (int j = 1; j < 255; j++)
                {
                    sb.Append($"10.0.{i}.{j}, ");
                    counter++;
                    if (counter > max) break;
                }
                if (counter > max) break;
            }

            string outputContent = sb.ToString().TrimEnd(new[] { ',', ' ' });

            File.WriteAllText(OutputPath, outputContent);
        }
    }
}

// For extra info, run:
// $FormatEnumerationLimit =-1
// Get-ReceiveConnector "Internet Receive Connector" | Select -ExpandProperty RemoteIPRanges
// (Get-ReceiveConnector "Internet Receive Connector").RemoteIPRanges.count