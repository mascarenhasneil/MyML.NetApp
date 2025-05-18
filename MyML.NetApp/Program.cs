using MyML_NetAppML.Model;
using System;

namespace MyML.NetApp
{
    sealed class Program
    {
        private Program() { } // Private constructor to prevent instantiation

        static void Main(string[] args)
        {
            // Adding input data
            ModelInput input = new ModelInput
            {
                SentimentText = ":Neil, Save this without renaming; as its marked for rapid training."
            };

            // Loading model and predict output of sample data
            ModelOutput result = ConsumeModel.Predict(input);

            // Displaying the imput statement and its predection (Sentimal Analysis).
            Console.WriteLine($"Text: {input.SentimentText}\nIs Toxic: {result.Prediction}");
        }
    }
}
