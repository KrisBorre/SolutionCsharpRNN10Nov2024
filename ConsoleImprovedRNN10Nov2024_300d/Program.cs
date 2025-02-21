using LibraryGlobalVectors10Nov2024;
using LibraryImprovedRNN10Nov2024;

// see solution SolutionCsharpGloVe3Sep2024, project ConsoleImprovedRNN1Nov2024_300d
namespace ConsoleImprovedRNN10Nov2024_300d
{
    internal class Program
    {
        /// <summary>
        /// ChatGPT-4o
        /// </summary>
        static void Main(string[] args)
        {
            string gloveFilePath = "../../../../../../../GloVe/glove.6B.300d.txt";
            int embeddingDim = 300;
            var glove = new GloveLoader(gloveFilePath, embeddingDim);


            int hiddenSize = 150;
            double learningRate = 0.0001;
            int epochs = 100000;
            /*
            Epoch 99890/100000, Loss: 8,932790175636841E-05
            Epoch 99891/100000, Loss: 8,932696633405149E-05
            Epoch 99892/100000, Loss: 8,932603093024986E-05
            Epoch 99893/100000, Loss: 8,932509554496252E-05
            Epoch 99894/100000, Loss: 8,932416017818986E-05
            Epoch 99895/100000, Loss: 8,932322482993088E-05
            Epoch 99896/100000, Loss: 8,932228950018565E-05
            Epoch 99897/100000, Loss: 8,93213541889538E-05
            Epoch 99898/100000, Loss: 8,932041889623484E-05
            Epoch 99899/100000, Loss: 8,931948362202874E-05
            Epoch 99900/100000, Loss: 8,931854836633493E-05
            Epoch 99901/100000, Loss: 8,931761312915342E-05
            Epoch 99902/100000, Loss: 8,931667791048355E-05
            Epoch 99903/100000, Loss: 8,931574271032534E-05
            Epoch 99904/100000, Loss: 8,931480752867824E-05
            Epoch 99905/100000, Loss: 8,931387236554209E-05
            Epoch 99906/100000, Loss: 8,931293722091644E-05
            Epoch 99907/100000, Loss: 8,931200209480098E-05
            Epoch 99908/100000, Loss: 8,931106698719604E-05
            Epoch 99909/100000, Loss: 8,931013189810043E-05
            Epoch 99910/100000, Loss: 8,930919682751405E-05
            Epoch 99911/100000, Loss: 8,930826177543695E-05
            Epoch 99912/100000, Loss: 8,930732674186848E-05
            Epoch 99913/100000, Loss: 8,930639172680854E-05
            Epoch 99914/100000, Loss: 8,930545673025666E-05
            Epoch 99915/100000, Loss: 8,930452175221279E-05
            Epoch 99916/100000, Loss: 8,93035867926763E-05
            Epoch 99917/100000, Loss: 8,930265185164712E-05
            Epoch 99918/100000, Loss: 8,930171692912486E-05
            Epoch 99919/100000, Loss: 8,930078202510943E-05
            Epoch 99920/100000, Loss: 8,929984713959992E-05
            Epoch 99921/100000, Loss: 8,92989122725966E-05
            Epoch 99922/100000, Loss: 8,929797742409897E-05
            Epoch 99923/100000, Loss: 8,92970425941069E-05
            Epoch 99924/100000, Loss: 8,929610778261966E-05
            Epoch 99925/100000, Loss: 8,929517298963736E-05
            Epoch 99926/100000, Loss: 8,92942382151595E-05
            Epoch 99927/100000, Loss: 8,929330345918584E-05
            Epoch 99928/100000, Loss: 8,929236872171616E-05
            Epoch 99929/100000, Loss: 8,929143400274983E-05
            Epoch 99930/100000, Loss: 8,929049930228704E-05
            Epoch 99931/100000, Loss: 8,928956462032684E-05
            Epoch 99932/100000, Loss: 8,928862995686971E-05
            Epoch 99933/100000, Loss: 8,92876953119149E-05
            Epoch 99934/100000, Loss: 8,928676068546184E-05
            Epoch 99935/100000, Loss: 8,928582607751052E-05
            Epoch 99936/100000, Loss: 8,928489148806083E-05
            Epoch 99937/100000, Loss: 8,928395691711223E-05
            Epoch 99938/100000, Loss: 8,928302236466435E-05
            Epoch 99939/100000, Loss: 8,92820878307168E-05
            Epoch 99940/100000, Loss: 8,928115331526963E-05
            Epoch 99941/100000, Loss: 8,92802188183226E-05
            Epoch 99942/100000, Loss: 8,927928433987472E-05
            Epoch 99943/100000, Loss: 8,927834987992658E-05
            Epoch 99944/100000, Loss: 8,927741543847707E-05
            Epoch 99945/100000, Loss: 8,927648101552647E-05
            Epoch 99946/100000, Loss: 8,927554661107422E-05
            Epoch 99947/100000, Loss: 8,92746122251199E-05
            Epoch 99948/100000, Loss: 8,927367785766348E-05
            Epoch 99949/100000, Loss: 8,927274350870451E-05
            Epoch 99950/100000, Loss: 8,927180917824254E-05
            Epoch 99951/100000, Loss: 8,927087486627763E-05
            Epoch 99952/100000, Loss: 8,926994057280919E-05
            Epoch 99953/100000, Loss: 8,92690062978369E-05
            Epoch 99954/100000, Loss: 8,926807204136051E-05
            Epoch 99955/100000, Loss: 8,926713780337986E-05
            Epoch 99956/100000, Loss: 8,926620358389445E-05
            Epoch 99957/100000, Loss: 8,926526938290416E-05
            Epoch 99958/100000, Loss: 8,926433520040834E-05
            Epoch 99959/100000, Loss: 8,926340103640726E-05
            Epoch 99960/100000, Loss: 8,926246689090014E-05
            Epoch 99961/100000, Loss: 8,926153276388646E-05
            Epoch 99962/100000, Loss: 8,926059865536681E-05
            Epoch 99963/100000, Loss: 8,925966456534003E-05
            Epoch 99964/100000, Loss: 8,925873049380622E-05
            Epoch 99965/100000, Loss: 8,925779644076505E-05
            Epoch 99966/100000, Loss: 8,925686240621587E-05
            Epoch 99967/100000, Loss: 8,925592839015903E-05
            Epoch 99968/100000, Loss: 8,925499439259346E-05
            Epoch 99969/100000, Loss: 8,925406041351964E-05
            Epoch 99970/100000, Loss: 8,925312645293673E-05
            Epoch 99971/100000, Loss: 8,925219251084431E-05
            Epoch 99972/100000, Loss: 8,925125858724251E-05
            Epoch 99973/100000, Loss: 8,925032468213082E-05
            Epoch 99974/100000, Loss: 8,924939079550922E-05
            Epoch 99975/100000, Loss: 8,92484569273765E-05
            Epoch 99976/100000, Loss: 8,924752307773348E-05
            Epoch 99977/100000, Loss: 8,92465892465796E-05
            Epoch 99978/100000, Loss: 8,924565543391381E-05
            Epoch 99979/100000, Loss: 8,924472163973651E-05
            Epoch 99980/100000, Loss: 8,924378786404717E-05
            Epoch 99981/100000, Loss: 8,924285410684551E-05
            Epoch 99982/100000, Loss: 8,92419203681312E-05
            Epoch 99983/100000, Loss: 8,924098664790408E-05
            Epoch 99984/100000, Loss: 8,924005294616364E-05
            Epoch 99985/100000, Loss: 8,923911926290972E-05
            Epoch 99986/100000, Loss: 8,923818559814195E-05
            Epoch 99987/100000, Loss: 8,923725195186017E-05
            Epoch 99988/100000, Loss: 8,923631832406367E-05
            Epoch 99989/100000, Loss: 8,923538471475255E-05
            Epoch 99990/100000, Loss: 8,923445112392621E-05
            Epoch 99991/100000, Loss: 8,923351755158482E-05
            Epoch 99992/100000, Loss: 8,923258399772753E-05
            Epoch 99993/100000, Loss: 8,923165046235446E-05
            Epoch 99994/100000, Loss: 8,923071694546515E-05
            Epoch 99995/100000, Loss: 8,922978344705869E-05
            Epoch 99996/100000, Loss: 8,922884996713596E-05
            Epoch 99997/100000, Loss: 8,922791650569555E-05
            Epoch 99998/100000, Loss: 8,922698306273801E-05
            Epoch 99999/100000, Loss: 8,922604963826242E-05
            Epoch 100000/100000, Loss: 8,922511623226872E-05
            Testing trained RNN on physics sentences:
            Input: energy is conserved in system
            Predicted: is conserved in system

            Input: force equals mass times acceleration
            Predicted: equals mass times acceleration

            Input: light travels in vacuum at speed
            Predicted: travels in vacuum at speed

            Input: electron has negative charge
            Predicted: has negative charge

            Input: gravity pulls objects towards earth
            Predicted: pulls objects towards earth
            */


            ImprovedRNN rnn = new ImprovedRNN(inputSize: embeddingDim, hiddenSize: hiddenSize, outputSize: embeddingDim, learningRate: learningRate);

            // Five physics-related sentences for training
            List<string[]> physicsSentences = new List<string[]>
            {
              new string[] { "energy", "is", "conserved", "in", "system" },
              new string[] { "force", "equals", "mass", "times", "acceleration" },
              new string[] { "light", "travels", "in", "vacuum", "at", "speed" },
              new string[] { "electron", "has", "negative", "charge" },
              new string[] { "gravity", "pulls", "objects", "towards", "earth" }
             };

            // Training the ImprovedRNN on these sentences
            for (int epoch = 0; epoch < epochs; epoch++)
            {
                double totalLoss = 0;

                foreach (var sentence in physicsSentences)
                {
                    List<double[]> physicsSentenceEmbeddings = sentence
                        .Select(word => glove.GetEmbedding(word))
                        .ToList();

                    for (int i = 0; i < physicsSentenceEmbeddings.Count - 1; i++)
                    {
                        double[] inputEmbedding = physicsSentenceEmbeddings[i];
                        double[] targetEmbedding = physicsSentenceEmbeddings[i + 1];

                        // Forward pass
                        double[] trainOutputEmbedding = rnn.Forward(inputEmbedding);

                        // Calculate Mean Squared Error loss for the current word pair
                        double loss = 0;
                        for (int j = 0; j < trainOutputEmbedding.Length; j++)
                        {
                            loss += Math.Pow(trainOutputEmbedding[j] - targetEmbedding[j], 2);
                        }
                        loss /= embeddingDim;
                        totalLoss += loss;

                        // Backward pass
                        rnn.Backward(trainOutputEmbedding, targetEmbedding, inputEmbedding);
                    }
                }

                totalLoss /= physicsSentences.Count;
                Console.WriteLine($"Epoch {epoch + 1}/{epochs}, Loss: {totalLoss}");
            }

            // Testing the ImprovedRNN to see if it can recall physics sentences
            Console.WriteLine("Testing trained RNN on physics sentences:");
            foreach (var sentence in physicsSentences)
            {
                Console.Write("Input: ");
                foreach (var word in sentence)
                {
                    Console.Write(word + " ");
                }
                Console.Write("\nPredicted: ");

                List<double[]> sentenceEmbeddings = sentence
                    .Select(word => glove.GetEmbedding(word))
                    .ToList();

                for (int i = 0; i < sentenceEmbeddings.Count - 1; i++)
                {
                    double[] physicsOutputEmbedding = rnn.Forward(sentenceEmbeddings[i]);
                    string predictedWord = glove.FindClosestWord(physicsOutputEmbedding);
                    Console.Write(predictedWord + " ");
                }
                Console.WriteLine("\n");
            }

            // Additional test sentences
            TestSentence(rnn, glove, new string[] { "ice", "age" });
            TestSentence(rnn, glove, new string[] { "proton", "has" });

            Console.Read();
        }

        static void TestSentence(ImprovedRNN rnn, GloveLoader glove, string[] sentence)
        {
            Console.Write("Input: ");
            foreach (var word in sentence)
            {
                Console.Write(word + " ");
            }
            Console.Write("\nPredicted: ");

            List<double[]> sentenceEmbeddings = sentence
                .Select(word => glove.GetEmbedding(word))
                .ToList();

            double[] outputEmbedding = null;
            for (int i = 0; i < sentenceEmbeddings.Count - 1; i++)
            {
                outputEmbedding = rnn.Forward(sentenceEmbeddings[i]);
                string predictedWord = glove.FindClosestWord(outputEmbedding);
                Console.Write(predictedWord + " ");
            }

            for (int i = 0; i < 3; i++)
            {
                outputEmbedding = rnn.Forward(outputEmbedding);
                string predictedWord = glove.FindClosestWord(outputEmbedding);
                Console.Write(predictedWord + " ");
            }
            Console.WriteLine("\n");
        }
    }
}
