using LibraryGlobalVectors10Nov2024;
using LibraryImprovedRNN10Nov2024;

namespace ConsoleImprovedRNN11Nov2024_300d
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
            double learningRate = 0.01;
            int epochs = 5000;
            /*
            Epoch 4503/5000, Loss: NaN
            Epoch 4504/5000, Loss: NaN
            Epoch 4505/5000, Loss: NaN
            Epoch 4506/5000, Loss: NaN
            Epoch 4507/5000, Loss: NaN
            Epoch 4508/5000, Loss: NaN
            Epoch 4509/5000, Loss: NaN
            Epoch 4510/5000, Loss: NaN
            Epoch 4511/5000, Loss: NaN
            Epoch 4512/5000, Loss: NaN
            Epoch 4513/5000, Loss: NaN
            Epoch 4514/5000, Loss: NaN
            Epoch 4515/5000, Loss: NaN
            Epoch 4516/5000, Loss: NaN
            Epoch 4517/5000, Loss: NaN
            Epoch 4518/5000, Loss: NaN
            Epoch 4519/5000, Loss: NaN
            Epoch 4520/5000, Loss: NaN
            Epoch 4521/5000, Loss: NaN
            Epoch 4522/5000, Loss: NaN
            Epoch 4523/5000, Loss: NaN
            Epoch 4524/5000, Loss: NaN
            Epoch 4525/5000, Loss: NaN
            Epoch 4526/5000, Loss: NaN
            Epoch 4527/5000, Loss: NaN
            Epoch 4528/5000, Loss: NaN
            Epoch 4529/5000, Loss: NaN
            Epoch 4530/5000, Loss: NaN
            Epoch 4531/5000, Loss: NaN
            Epoch 4532/5000, Loss: NaN
            Epoch 4533/5000, Loss: NaN
            Epoch 4534/5000, Loss: NaN
            Epoch 4535/5000, Loss: NaN
            Epoch 4536/5000, Loss: NaN
            Epoch 4537/5000, Loss: NaN
            Epoch 4538/5000, Loss: NaN
            Epoch 4539/5000, Loss: NaN
            Epoch 4540/5000, Loss: NaN
            Epoch 4541/5000, Loss: NaN
            Epoch 4542/5000, Loss: NaN
            Epoch 4543/5000, Loss: NaN
            Epoch 4544/5000, Loss: NaN
            Epoch 4545/5000, Loss: NaN
            Epoch 4546/5000, Loss: NaN
            Epoch 4547/5000, Loss: NaN
            Epoch 4548/5000, Loss: NaN
            Epoch 4549/5000, Loss: NaN
            Epoch 4550/5000, Loss: NaN
            Epoch 4551/5000, Loss: NaN
            Epoch 4552/5000, Loss: NaN
            Epoch 4553/5000, Loss: NaN
            Epoch 4554/5000, Loss: NaN
            Epoch 4555/5000, Loss: NaN
            Epoch 4556/5000, Loss: NaN
            Epoch 4557/5000, Loss: NaN
            Epoch 4558/5000, Loss: NaN
            Epoch 4559/5000, Loss: NaN
            Epoch 4560/5000, Loss: NaN
            Epoch 4561/5000, Loss: NaN
            Epoch 4562/5000, Loss: NaN
            Epoch 4563/5000, Loss: NaN
            Epoch 4564/5000, Loss: NaN
            Epoch 4565/5000, Loss: NaN
            Epoch 4566/5000, Loss: NaN
            Epoch 4567/5000, Loss: NaN
            Epoch 4568/5000, Loss: NaN
            Epoch 4569/5000, Loss: NaN
            Epoch 4570/5000, Loss: NaN
            Epoch 4571/5000, Loss: NaN
            Epoch 4572/5000, Loss: NaN
            Epoch 4573/5000, Loss: NaN
            Epoch 4574/5000, Loss: NaN
            Epoch 4575/5000, Loss: NaN
            Epoch 4576/5000, Loss: NaN
            Epoch 4577/5000, Loss: NaN
            Epoch 4578/5000, Loss: NaN
            Epoch 4579/5000, Loss: NaN
            Epoch 4580/5000, Loss: NaN
            Epoch 4581/5000, Loss: NaN
            Epoch 4582/5000, Loss: NaN
            Epoch 4583/5000, Loss: NaN
            Epoch 4584/5000, Loss: NaN
            Epoch 4585/5000, Loss: NaN
            Epoch 4586/5000, Loss: NaN
            Epoch 4587/5000, Loss: NaN
            Epoch 4588/5000, Loss: NaN
            Epoch 4589/5000, Loss: NaN
            Epoch 4590/5000, Loss: NaN
            Epoch 4591/5000, Loss: NaN
            Epoch 4592/5000, Loss: NaN
            Epoch 4593/5000, Loss: NaN
            Epoch 4594/5000, Loss: NaN
            Epoch 4595/5000, Loss: NaN
            Epoch 4596/5000, Loss: NaN
            Epoch 4597/5000, Loss: NaN
            Epoch 4598/5000, Loss: NaN
            Epoch 4599/5000, Loss: NaN
            Epoch 4600/5000, Loss: NaN
            Epoch 4601/5000, Loss: NaN
            Epoch 4602/5000, Loss: NaN
            Epoch 4603/5000, Loss: NaN
            Epoch 4604/5000, Loss: NaN
            Epoch 4605/5000, Loss: NaN
            Epoch 4606/5000, Loss: NaN
            Epoch 4607/5000, Loss: NaN
            Epoch 4608/5000, Loss: NaN
            Epoch 4609/5000, Loss: NaN
            Epoch 4610/5000, Loss: NaN
            Epoch 4611/5000, Loss: NaN
            Epoch 4612/5000, Loss: NaN
            Epoch 4613/5000, Loss: NaN
            Epoch 4614/5000, Loss: NaN
            Epoch 4615/5000, Loss: NaN
            Epoch 4616/5000, Loss: NaN
            Epoch 4617/5000, Loss: NaN
            Epoch 4618/5000, Loss: NaN
            Epoch 4619/5000, Loss: NaN
            Epoch 4620/5000, Loss: NaN
            Epoch 4621/5000, Loss: NaN
            Epoch 4622/5000, Loss: NaN
            Epoch 4623/5000, Loss: NaN
            Epoch 4624/5000, Loss: NaN
            Epoch 4625/5000, Loss: NaN
            Epoch 4626/5000, Loss: NaN
            Epoch 4627/5000, Loss: NaN
            Epoch 4628/5000, Loss: NaN
            Epoch 4629/5000, Loss: NaN
            Epoch 4630/5000, Loss: NaN
            Epoch 4631/5000, Loss: NaN
            Epoch 4632/5000, Loss: NaN
            Epoch 4633/5000, Loss: NaN
            Epoch 4634/5000, Loss: NaN
            Epoch 4635/5000, Loss: NaN
            Epoch 4636/5000, Loss: NaN
            Epoch 4637/5000, Loss: NaN
            Epoch 4638/5000, Loss: NaN
            Epoch 4639/5000, Loss: NaN
            Epoch 4640/5000, Loss: NaN
            Epoch 4641/5000, Loss: NaN
            Epoch 4642/5000, Loss: NaN
            Epoch 4643/5000, Loss: NaN
            Epoch 4644/5000, Loss: NaN
            Epoch 4645/5000, Loss: NaN
            Epoch 4646/5000, Loss: NaN
            Epoch 4647/5000, Loss: NaN
            Epoch 4648/5000, Loss: NaN
            Epoch 4649/5000, Loss: NaN
            Epoch 4650/5000, Loss: NaN
            Epoch 4651/5000, Loss: NaN
            Epoch 4652/5000, Loss: NaN
            Epoch 4653/5000, Loss: NaN
            Epoch 4654/5000, Loss: NaN
            Epoch 4655/5000, Loss: NaN
            Epoch 4656/5000, Loss: NaN
            Epoch 4657/5000, Loss: NaN
            Epoch 4658/5000, Loss: NaN
            Epoch 4659/5000, Loss: NaN
            Epoch 4660/5000, Loss: NaN
            Epoch 4661/5000, Loss: NaN
            Epoch 4662/5000, Loss: NaN
            Epoch 4663/5000, Loss: NaN
            Epoch 4664/5000, Loss: NaN
            Epoch 4665/5000, Loss: NaN
            Epoch 4666/5000, Loss: NaN
            Epoch 4667/5000, Loss: NaN
            Epoch 4668/5000, Loss: NaN
            Epoch 4669/5000, Loss: NaN
            Epoch 4670/5000, Loss: NaN
            Epoch 4671/5000, Loss: NaN
            Epoch 4672/5000, Loss: NaN
            Epoch 4673/5000, Loss: NaN
            Epoch 4674/5000, Loss: NaN
            Epoch 4675/5000, Loss: NaN
            Epoch 4676/5000, Loss: NaN
            Epoch 4677/5000, Loss: NaN
            Epoch 4678/5000, Loss: NaN
            Epoch 4679/5000, Loss: NaN
            Epoch 4680/5000, Loss: NaN
            Epoch 4681/5000, Loss: NaN
            Epoch 4682/5000, Loss: NaN
            Epoch 4683/5000, Loss: NaN
            Epoch 4684/5000, Loss: NaN
            Epoch 4685/5000, Loss: NaN
            Epoch 4686/5000, Loss: NaN
            Epoch 4687/5000, Loss: NaN
            Epoch 4688/5000, Loss: NaN
            Epoch 4689/5000, Loss: NaN
            Epoch 4690/5000, Loss: NaN
            Epoch 4691/5000, Loss: NaN
            Epoch 4692/5000, Loss: NaN
            Epoch 4693/5000, Loss: NaN
            Epoch 4694/5000, Loss: NaN
            Epoch 4695/5000, Loss: NaN
            Epoch 4696/5000, Loss: NaN
            Epoch 4697/5000, Loss: NaN
            Epoch 4698/5000, Loss: NaN
            Epoch 4699/5000, Loss: NaN
            Epoch 4700/5000, Loss: NaN
            Epoch 4701/5000, Loss: NaN
            Epoch 4702/5000, Loss: NaN
            Epoch 4703/5000, Loss: NaN
            Epoch 4704/5000, Loss: NaN
            Epoch 4705/5000, Loss: NaN
            Epoch 4706/5000, Loss: NaN
            Epoch 4707/5000, Loss: NaN
            Epoch 4708/5000, Loss: NaN
            Epoch 4709/5000, Loss: NaN
            Epoch 4710/5000, Loss: NaN
            Epoch 4711/5000, Loss: NaN
            Epoch 4712/5000, Loss: NaN
            Epoch 4713/5000, Loss: NaN
            Epoch 4714/5000, Loss: NaN
            Epoch 4715/5000, Loss: NaN
            Epoch 4716/5000, Loss: NaN
            Epoch 4717/5000, Loss: NaN
            Epoch 4718/5000, Loss: NaN
            Epoch 4719/5000, Loss: NaN
            Epoch 4720/5000, Loss: NaN
            Epoch 4721/5000, Loss: NaN
            Epoch 4722/5000, Loss: NaN
            Epoch 4723/5000, Loss: NaN
            Epoch 4724/5000, Loss: NaN
            Epoch 4725/5000, Loss: NaN
            Epoch 4726/5000, Loss: NaN
            Epoch 4727/5000, Loss: NaN
            Epoch 4728/5000, Loss: NaN
            Epoch 4729/5000, Loss: NaN
            Epoch 4730/5000, Loss: NaN
            Epoch 4731/5000, Loss: NaN
            Epoch 4732/5000, Loss: NaN
            Epoch 4733/5000, Loss: NaN
            Epoch 4734/5000, Loss: NaN
            Epoch 4735/5000, Loss: NaN
            Epoch 4736/5000, Loss: NaN
            Epoch 4737/5000, Loss: NaN
            Epoch 4738/5000, Loss: NaN
            Epoch 4739/5000, Loss: NaN
            Epoch 4740/5000, Loss: NaN
            Epoch 4741/5000, Loss: NaN
            Epoch 4742/5000, Loss: NaN
            Epoch 4743/5000, Loss: NaN
            Epoch 4744/5000, Loss: NaN
            Epoch 4745/5000, Loss: NaN
            Epoch 4746/5000, Loss: NaN
            Epoch 4747/5000, Loss: NaN
            Epoch 4748/5000, Loss: NaN
            Epoch 4749/5000, Loss: NaN
            Epoch 4750/5000, Loss: NaN
            Epoch 4751/5000, Loss: NaN
            Epoch 4752/5000, Loss: NaN
            Epoch 4753/5000, Loss: NaN
            Epoch 4754/5000, Loss: NaN
            Epoch 4755/5000, Loss: NaN
            Epoch 4756/5000, Loss: NaN
            Epoch 4757/5000, Loss: NaN
            Epoch 4758/5000, Loss: NaN
            Epoch 4759/5000, Loss: NaN
            Epoch 4760/5000, Loss: NaN
            Epoch 4761/5000, Loss: NaN
            Epoch 4762/5000, Loss: NaN
            Epoch 4763/5000, Loss: NaN
            Epoch 4764/5000, Loss: NaN
            Epoch 4765/5000, Loss: NaN
            Epoch 4766/5000, Loss: NaN
            Epoch 4767/5000, Loss: NaN
            Epoch 4768/5000, Loss: NaN
            Epoch 4769/5000, Loss: NaN
            Epoch 4770/5000, Loss: NaN
            Epoch 4771/5000, Loss: NaN
            Epoch 4772/5000, Loss: NaN
            Epoch 4773/5000, Loss: NaN
            Epoch 4774/5000, Loss: NaN
            Epoch 4775/5000, Loss: NaN
            Epoch 4776/5000, Loss: NaN
            Epoch 4777/5000, Loss: NaN
            Epoch 4778/5000, Loss: NaN
            Epoch 4779/5000, Loss: NaN
            Epoch 4780/5000, Loss: NaN
            Epoch 4781/5000, Loss: NaN
            Epoch 4782/5000, Loss: NaN
            Epoch 4783/5000, Loss: NaN
            Epoch 4784/5000, Loss: NaN
            Epoch 4785/5000, Loss: NaN
            Epoch 4786/5000, Loss: NaN
            Epoch 4787/5000, Loss: NaN
            Epoch 4788/5000, Loss: NaN
            Epoch 4789/5000, Loss: NaN
            Epoch 4790/5000, Loss: NaN
            Epoch 4791/5000, Loss: NaN
            Epoch 4792/5000, Loss: NaN
            Epoch 4793/5000, Loss: NaN
            Epoch 4794/5000, Loss: NaN
            Epoch 4795/5000, Loss: NaN
            Epoch 4796/5000, Loss: NaN
            Epoch 4797/5000, Loss: NaN
            Epoch 4798/5000, Loss: NaN
            Epoch 4799/5000, Loss: NaN
            Epoch 4800/5000, Loss: NaN
            Epoch 4801/5000, Loss: NaN
            Epoch 4802/5000, Loss: NaN
            Epoch 4803/5000, Loss: NaN
            Epoch 4804/5000, Loss: NaN
            Epoch 4805/5000, Loss: NaN
            Epoch 4806/5000, Loss: NaN
            Epoch 4807/5000, Loss: NaN
            Epoch 4808/5000, Loss: NaN
            Epoch 4809/5000, Loss: NaN
            Epoch 4810/5000, Loss: NaN
            Epoch 4811/5000, Loss: NaN
            Epoch 4812/5000, Loss: NaN
            Epoch 4813/5000, Loss: NaN
            Epoch 4814/5000, Loss: NaN
            Epoch 4815/5000, Loss: NaN
            Epoch 4816/5000, Loss: NaN
            Epoch 4817/5000, Loss: NaN
            Epoch 4818/5000, Loss: NaN
            Epoch 4819/5000, Loss: NaN
            Epoch 4820/5000, Loss: NaN
            Epoch 4821/5000, Loss: NaN
            Epoch 4822/5000, Loss: NaN
            Epoch 4823/5000, Loss: NaN
            Epoch 4824/5000, Loss: NaN
            Epoch 4825/5000, Loss: NaN
            Epoch 4826/5000, Loss: NaN
            Epoch 4827/5000, Loss: NaN
            Epoch 4828/5000, Loss: NaN
            Epoch 4829/5000, Loss: NaN
            Epoch 4830/5000, Loss: NaN
            Epoch 4831/5000, Loss: NaN
            Epoch 4832/5000, Loss: NaN
            Epoch 4833/5000, Loss: NaN
            Epoch 4834/5000, Loss: NaN
            Epoch 4835/5000, Loss: NaN
            Epoch 4836/5000, Loss: NaN
            Epoch 4837/5000, Loss: NaN
            Epoch 4838/5000, Loss: NaN
            Epoch 4839/5000, Loss: NaN
            Epoch 4840/5000, Loss: NaN
            Epoch 4841/5000, Loss: NaN
            Epoch 4842/5000, Loss: NaN
            Epoch 4843/5000, Loss: NaN
            Epoch 4844/5000, Loss: NaN
            Epoch 4845/5000, Loss: NaN
            Epoch 4846/5000, Loss: NaN
            Epoch 4847/5000, Loss: NaN
            Epoch 4848/5000, Loss: NaN
            Epoch 4849/5000, Loss: NaN
            Epoch 4850/5000, Loss: NaN
            Epoch 4851/5000, Loss: NaN
            Epoch 4852/5000, Loss: NaN
            Epoch 4853/5000, Loss: NaN
            Epoch 4854/5000, Loss: NaN
            Epoch 4855/5000, Loss: NaN
            Epoch 4856/5000, Loss: NaN
            Epoch 4857/5000, Loss: NaN
            Epoch 4858/5000, Loss: NaN
            Epoch 4859/5000, Loss: NaN
            Epoch 4860/5000, Loss: NaN
            Epoch 4861/5000, Loss: NaN
            Epoch 4862/5000, Loss: NaN
            Epoch 4863/5000, Loss: NaN
            Epoch 4864/5000, Loss: NaN
            Epoch 4865/5000, Loss: NaN
            Epoch 4866/5000, Loss: NaN
            Epoch 4867/5000, Loss: NaN
            Epoch 4868/5000, Loss: NaN
            Epoch 4869/5000, Loss: NaN
            Epoch 4870/5000, Loss: NaN
            Epoch 4871/5000, Loss: NaN
            Epoch 4872/5000, Loss: NaN
            Epoch 4873/5000, Loss: NaN
            Epoch 4874/5000, Loss: NaN
            Epoch 4875/5000, Loss: NaN
            Epoch 4876/5000, Loss: NaN
            Epoch 4877/5000, Loss: NaN
            Epoch 4878/5000, Loss: NaN
            Epoch 4879/5000, Loss: NaN
            Epoch 4880/5000, Loss: NaN
            Epoch 4881/5000, Loss: NaN
            Epoch 4882/5000, Loss: NaN
            Epoch 4883/5000, Loss: NaN
            Epoch 4884/5000, Loss: NaN
            Epoch 4885/5000, Loss: NaN
            Epoch 4886/5000, Loss: NaN
            Epoch 4887/5000, Loss: NaN
            Epoch 4888/5000, Loss: NaN
            Epoch 4889/5000, Loss: NaN
            Epoch 4890/5000, Loss: NaN
            Epoch 4891/5000, Loss: NaN
            Epoch 4892/5000, Loss: NaN
            Epoch 4893/5000, Loss: NaN
            Epoch 4894/5000, Loss: NaN
            Epoch 4895/5000, Loss: NaN
            Epoch 4896/5000, Loss: NaN
            Epoch 4897/5000, Loss: NaN
            Epoch 4898/5000, Loss: NaN
            Epoch 4899/5000, Loss: NaN
            Epoch 4900/5000, Loss: NaN
            Epoch 4901/5000, Loss: NaN
            Epoch 4902/5000, Loss: NaN
            Epoch 4903/5000, Loss: NaN
            Epoch 4904/5000, Loss: NaN
            Epoch 4905/5000, Loss: NaN
            Epoch 4906/5000, Loss: NaN
            Epoch 4907/5000, Loss: NaN
            Epoch 4908/5000, Loss: NaN
            Epoch 4909/5000, Loss: NaN
            Epoch 4910/5000, Loss: NaN
            Epoch 4911/5000, Loss: NaN
            Epoch 4912/5000, Loss: NaN
            Epoch 4913/5000, Loss: NaN
            Epoch 4914/5000, Loss: NaN
            Epoch 4915/5000, Loss: NaN
            Epoch 4916/5000, Loss: NaN
            Epoch 4917/5000, Loss: NaN
            Epoch 4918/5000, Loss: NaN
            Epoch 4919/5000, Loss: NaN
            Epoch 4920/5000, Loss: NaN
            Epoch 4921/5000, Loss: NaN
            Epoch 4922/5000, Loss: NaN
            Epoch 4923/5000, Loss: NaN
            Epoch 4924/5000, Loss: NaN
            Epoch 4925/5000, Loss: NaN
            Epoch 4926/5000, Loss: NaN
            Epoch 4927/5000, Loss: NaN
            Epoch 4928/5000, Loss: NaN
            Epoch 4929/5000, Loss: NaN
            Epoch 4930/5000, Loss: NaN
            Epoch 4931/5000, Loss: NaN
            Epoch 4932/5000, Loss: NaN
            Epoch 4933/5000, Loss: NaN
            Epoch 4934/5000, Loss: NaN
            Epoch 4935/5000, Loss: NaN
            Epoch 4936/5000, Loss: NaN
            Epoch 4937/5000, Loss: NaN
            Epoch 4938/5000, Loss: NaN
            Epoch 4939/5000, Loss: NaN
            Epoch 4940/5000, Loss: NaN
            Epoch 4941/5000, Loss: NaN
            Epoch 4942/5000, Loss: NaN
            Epoch 4943/5000, Loss: NaN
            Epoch 4944/5000, Loss: NaN
            Epoch 4945/5000, Loss: NaN
            Epoch 4946/5000, Loss: NaN
            Epoch 4947/5000, Loss: NaN
            Epoch 4948/5000, Loss: NaN
            Epoch 4949/5000, Loss: NaN
            Epoch 4950/5000, Loss: NaN
            Epoch 4951/5000, Loss: NaN
            Epoch 4952/5000, Loss: NaN
            Epoch 4953/5000, Loss: NaN
            Epoch 4954/5000, Loss: NaN
            Epoch 4955/5000, Loss: NaN
            Epoch 4956/5000, Loss: NaN
            Epoch 4957/5000, Loss: NaN
            Epoch 4958/5000, Loss: NaN
            Epoch 4959/5000, Loss: NaN
            Epoch 4960/5000, Loss: NaN
            Epoch 4961/5000, Loss: NaN
            Epoch 4962/5000, Loss: NaN
            Epoch 4963/5000, Loss: NaN
            Epoch 4964/5000, Loss: NaN
            Epoch 4965/5000, Loss: NaN
            Epoch 4966/5000, Loss: NaN
            Epoch 4967/5000, Loss: NaN
            Epoch 4968/5000, Loss: NaN
            Epoch 4969/5000, Loss: NaN
            Epoch 4970/5000, Loss: NaN
            Epoch 4971/5000, Loss: NaN
            Epoch 4972/5000, Loss: NaN
            Epoch 4973/5000, Loss: NaN
            Epoch 4974/5000, Loss: NaN
            Epoch 4975/5000, Loss: NaN
            Epoch 4976/5000, Loss: NaN
            Epoch 4977/5000, Loss: NaN
            Epoch 4978/5000, Loss: NaN
            Epoch 4979/5000, Loss: NaN
            Epoch 4980/5000, Loss: NaN
            Epoch 4981/5000, Loss: NaN
            Epoch 4982/5000, Loss: NaN
            Epoch 4983/5000, Loss: NaN
            Epoch 4984/5000, Loss: NaN
            Epoch 4985/5000, Loss: NaN
            Epoch 4986/5000, Loss: NaN
            Epoch 4987/5000, Loss: NaN
            Epoch 4988/5000, Loss: NaN
            Epoch 4989/5000, Loss: NaN
            Epoch 4990/5000, Loss: NaN
            Epoch 4991/5000, Loss: NaN
            Epoch 4992/5000, Loss: NaN
            Epoch 4993/5000, Loss: NaN
            Epoch 4994/5000, Loss: NaN
            Epoch 4995/5000, Loss: NaN
            Epoch 4996/5000, Loss: NaN
            Epoch 4997/5000, Loss: NaN
            Epoch 4998/5000, Loss: NaN
            Epoch 4999/5000, Loss: NaN
            Epoch 5000/5000, Loss: NaN
            Testing trained RNN on physics sentences:
            Input: energy cannot be created or destroyed only transformed
            Predicted:

            Input: an object in motion stays in motion unless acted upon by external force
            Predicted:

            Input: the speed of light in vacuum is a fundamental constant of nature
            Predicted:

            Input: electrons occupy discrete energy levels around the nucleus of an atom
            Predicted:

            Input: gravitational force between two masses is directly proportional to their product and inversely proportional to square of distance
            Predicted:

            Input: ice age
            Predicted:

            Input: proton has
            Predicted: 
            */

            //int hiddenSize = 150;
            //double learningRate = 0.001;
            //int epochs = 5000;
            /*
             Epoch 4575/5000, Loss: 0,0020372604619564366
Epoch 4576/5000, Loss: 0,0020368677782612137
Epoch 4577/5000, Loss: 0,002036475300232219
Epoch 4578/5000, Loss: 0,0020360830276710553
Epoch 4579/5000, Loss: 0,0020356909603794094
Epoch 4580/5000, Loss: 0,002035299098159052
Epoch 4581/5000, Loss: 0,002034907440811833
Epoch 4582/5000, Loss: 0,00203451598813969
Epoch 4583/5000, Loss: 0,002034124739944644
Epoch 4584/5000, Loss: 0,002033733696028806
Epoch 4585/5000, Loss: 0,002033342856194374
Epoch 4586/5000, Loss: 0,0020329522202436347
Epoch 4587/5000, Loss: 0,0020325617879789625
Epoch 4588/5000, Loss: 0,0020321715592028296
Epoch 4589/5000, Loss: 0,0020317815337177964
Epoch 4590/5000, Loss: 0,0020313917113265164
Epoch 4591/5000, Loss: 0,002031002091831744
Epoch 4592/5000, Loss: 0,002030612675036322
Epoch 4593/5000, Loss: 0,002030223460743199
Epoch 4594/5000, Loss: 0,0020298344487554125
Epoch 4595/5000, Loss: 0,0020294456388761078
Epoch 4596/5000, Loss: 0,0020290570309085274
Epoch 4597/5000, Loss: 0,0020286686246560157
Epoch 4598/5000, Loss: 0,002028280419922021
Epoch 4599/5000, Loss: 0,002027892416510096
Epoch 4600/5000, Loss: 0,002027504614223896
Epoch 4601/5000, Loss: 0,002027117012867186
Epoch 4602/5000, Loss: 0,002026729612243839
Epoch 4603/5000, Loss: 0,0020263424121578335
Epoch 4604/5000, Loss: 0,0020259554124132583
Epoch 4605/5000, Loss: 0,002025568612814316
Epoch 4606/5000, Loss: 0,002025182013165319
Epoch 4607/5000, Loss: 0,002024795613270694
Epoch 4608/5000, Loss: 0,0020244094129349814
Epoch 4609/5000, Loss: 0,0020240234119628365
Epoch 4610/5000, Loss: 0,0020236376101590322
Epoch 4611/5000, Loss: 0,0020232520073284574
Epoch 4612/5000, Loss: 0,0020228666032761217
Epoch 4613/5000, Loss: 0,0020224813978071536
Epoch 4614/5000, Loss: 0,002022096390726802
Epoch 4615/5000, Loss: 0,0020217115818404407
Epoch 4616/5000, Loss: 0,0020213269709535614
Epoch 4617/5000, Loss: 0,0020209425578717835
Epoch 4618/5000, Loss: 0,0020205583424008533
Epoch 4619/5000, Loss: 0,0020201743243466394
Epoch 4620/5000, Loss: 0,0020197905035151406
Epoch 4621/5000, Loss: 0,002019406879712486
Epoch 4622/5000, Loss: 0,002019023452744928
Epoch 4623/5000, Loss: 0,002018640222418856
Epoch 4624/5000, Loss: 0,002018257188540789
Epoch 4625/5000, Loss: 0,002017874350917379
Epoch 4626/5000, Loss: 0,00201749170935541
Epoch 4627/5000, Loss: 0,002017109263661806
Epoch 4628/5000, Loss: 0,0020167270136436225
Epoch 4629/5000, Loss: 0,002016344959108054
Epoch 4630/5000, Loss: 0,002015963099862431
Epoch 4631/5000, Loss: 0,0020155814357142284
Epoch 4632/5000, Loss: 0,0020151999664710556
Epoch 4633/5000, Loss: 0,0020148186919406673
Epoch 4634/5000, Loss: 0,0020144376119309625
Epoch 4635/5000, Loss: 0,0020140567262499744
Epoch 4636/5000, Loss: 0,0020136760347058916
Epoch 4637/5000, Loss: 0,002013295537107043
Epoch 4638/5000, Loss: 0,0020129152332619043
Epoch 4639/5000, Loss: 0,002012535122979099
Epoch 4640/5000, Loss: 0,0020121552060674017
Epoch 4641/5000, Loss: 0,0020117754823357303
Epoch 4642/5000, Loss: 0,0020113959515931645
Epoch 4643/5000, Loss: 0,002011016613648925
Epoch 4644/5000, Loss: 0,00201063746831239
Epoch 4645/5000, Loss: 0,0020102585153930915
Epoch 4646/5000, Loss: 0,0020098797547007186
Epoch 4647/5000, Loss: 0,0020095011860451093
Epoch 4648/5000, Loss: 0,002009122809236266
Epoch 4649/5000, Loss: 0,002008744624084344
Epoch 4650/5000, Loss: 0,002008366630399661
Epoch 4651/5000, Loss: 0,0020079888279926914
Epoch 4652/5000, Loss: 0,002007611216674073
Epoch 4653/5000, Loss: 0,0020072337962546054
Epoch 4654/5000, Loss: 0,0020068565665452495
Epoch 4655/5000, Loss: 0,0020064795273571313
Epoch 4656/5000, Loss: 0,0020061026785015397
Epoch 4657/5000, Loss: 0,0020057260197899334
Epoch 4658/5000, Loss: 0,002005349551033935
Epoch 4659/5000, Loss: 0,002004973272045333
Epoch 4660/5000, Loss: 0,0020045971826360906
Epoch 4661/5000, Loss: 0,0020042212826183368
Epoch 4662/5000, Loss: 0,0020038455718043697
Epoch 4663/5000, Loss: 0,002003470050006666
Epoch 4664/5000, Loss: 0,0020030947170378657
Epoch 4665/5000, Loss: 0,0020027195727107894
Epoch 4666/5000, Loss: 0,0020023446168384315
Epoch 4667/5000, Loss: 0,002001969849233957
Epoch 4668/5000, Loss: 0,002001595269710715
Epoch 4669/5000, Loss: 0,0020012208780822256
Epoch 4670/5000, Loss: 0,002000846674162191
Epoch 4671/5000, Loss: 0,0020004726577644897
Epoch 4672/5000, Loss: 0,002000098828703185
Epoch 4673/5000, Loss: 0,0019997251867925185
Epoch 4674/5000, Loss: 0,001999351731846912
Epoch 4675/5000, Loss: 0,001998978463680974
Epoch 4676/5000, Loss: 0,001998605382109495
Epoch 4677/5000, Loss: 0,0019982324869474532
Epoch 4678/5000, Loss: 0,0019978597780100095
Epoch 4679/5000, Loss: 0,0019974872551125115
Epoch 4680/5000, Loss: 0,0019971149180704967
Epoch 4681/5000, Loss: 0,0019967427666996882
Epoch 4682/5000, Loss: 0,0019963708008160033
Epoch 4683/5000, Loss: 0,0019959990202355468
Epoch 4684/5000, Loss: 0,0019956274247746137
Epoch 4685/5000, Loss: 0,0019952560142496916
Epoch 4686/5000, Loss: 0,001994884788477465
Epoch 4687/5000, Loss: 0,0019945137472748083
Epoch 4688/5000, Loss: 0,00199414289045879
Epoch 4689/5000, Loss: 0,0019937722178466786
Epoch 4690/5000, Loss: 0,0019934017292559383
Epoch 4691/5000, Loss: 0,0019930314245042258
Epoch 4692/5000, Loss: 0,0019926613034094024
Epoch 4693/5000, Loss: 0,001992291365789526
Epoch 4694/5000, Loss: 0,0019919216114628537
Epoch 4695/5000, Loss: 0,001991552040247847
Epoch 4696/5000, Loss: 0,0019911826519631672
Epoch 4697/5000, Loss: 0,001990813446427674
Epoch 4698/5000, Loss: 0,001990444423460441
Epoch 4699/5000, Loss: 0,0019900755828807354
Epoch 4700/5000, Loss: 0,0019897069245080373
Epoch 4701/5000, Loss: 0,0019893384481620285
Epoch 4702/5000, Loss: 0,0019889701536625988
Epoch 4703/5000, Loss: 0,0019886020408298494
Epoch 4704/5000, Loss: 0,0019882341094840826
Epoch 4705/5000, Loss: 0,001987866359445819
Epoch 4706/5000, Loss: 0,0019874987905357825
Epoch 4707/5000, Loss: 0,0019871314025749127
Epoch 4708/5000, Loss: 0,001986764195384356
Epoch 4709/5000, Loss: 0,001986397168785479
Epoch 4710/5000, Loss: 0,001986030322599855
Epoch 4711/5000, Loss: 0,001985663656649275
Epoch 4712/5000, Loss: 0,0019852971707557446
Epoch 4713/5000, Loss: 0,0019849308647414857
Epoch 4714/5000, Loss: 0,0019845647384289346
Epoch 4715/5000, Loss: 0,001984198791640751
Epoch 4716/5000, Loss: 0,001983833024199807
Epoch 4717/5000, Loss: 0,0019834674359291964
Epoch 4718/5000, Loss: 0,001983102026652232
Epoch 4719/5000, Loss: 0,0019827367961924493
Epoch 4720/5000, Loss: 0,0019823717443736037
Epoch 4721/5000, Loss: 0,001982006871019672
Epoch 4722/5000, Loss: 0,001981642175954856
Epoch 4723/5000, Loss: 0,001981277659003582
Epoch 4724/5000, Loss: 0,001980913319990498
Epoch 4725/5000, Loss: 0,001980549158740481
Epoch 4726/5000, Loss: 0,0019801851750786284
Epoch 4727/5000, Loss: 0,0019798213688302715
Epoch 4728/5000, Loss: 0,0019794577398209658
Epoch 4729/5000, Loss: 0,0019790942878764916
Epoch 4730/5000, Loss: 0,001978731012822865
Epoch 4731/5000, Loss: 0,001978367914486328
Epoch 4732/5000, Loss: 0,001978004992693356
Epoch 4733/5000, Loss: 0,0019776422472706505
Epoch 4734/5000, Loss: 0,0019772796780451523
Epoch 4735/5000, Loss: 0,0019769172848440276
Epoch 4736/5000, Loss: 0,0019765550674946822
Epoch 4737/5000, Loss: 0,001976193025824752
Epoch 4738/5000, Loss: 0,0019758311596621086
Epoch 4739/5000, Loss: 0,001975469468834863
Epoch 4740/5000, Loss: 0,0019751079531713568
Epoch 4741/5000, Loss: 0,0019747466125001716
Epoch 4742/5000, Loss: 0,0019743854466501296
Epoch 4743/5000, Loss: 0,001974024455450285
Epoch 4744/5000, Loss: 0,0019736636387299375
Epoch 4745/5000, Loss: 0,0019733029963186215
Epoch 4746/5000, Loss: 0,0019729425280461147
Epoch 4747/5000, Loss: 0,001972582233742437
Epoch 4748/5000, Loss: 0,0019722221132378475
Epoch 4749/5000, Loss: 0,001971862166362851
Epoch 4750/5000, Loss: 0,0019715023929481918
Epoch 4751/5000, Loss: 0,001971142792824859
Epoch 4752/5000, Loss: 0,0019707833658240913
Epoch 4753/5000, Loss: 0,0019704241117773644
Epoch 4754/5000, Loss: 0,0019700650305164067
Epoch 4755/5000, Loss: 0,001969706121873191
Epoch 4756/5000, Loss: 0,0019693473856799352
Epoch 4757/5000, Loss: 0,0019689888217691086
Epoch 4758/5000, Loss: 0,0019686304299734256
Epoch 4759/5000, Loss: 0,0019682722101258534
Epoch 4760/5000, Loss: 0,001967914162059605
Epoch 4761/5000, Loss: 0,001967556285608146
Epoch 4762/5000, Loss: 0,001967198580605194
Epoch 4763/5000, Loss: 0,0019668410468847166
Epoch 4764/5000, Loss: 0,0019664836842809338
Epoch 4765/5000, Loss: 0,0019661264926283195
Epoch 4766/5000, Loss: 0,0019657694717616007
Epoch 4767/5000, Loss: 0,001965412621515757
Epoch 4768/5000, Loss: 0,001965055941726026
Epoch 4769/5000, Loss: 0,0019646994322278974
Epoch 4770/5000, Loss: 0,0019643430928571186
Epoch 4771/5000, Loss: 0,001963986923449693
Epoch 4772/5000, Loss: 0,0019636309238418815
Epoch 4773/5000, Loss: 0,0019632750938702037
Epoch 4774/5000, Loss: 0,0019629194333714347
Epoch 4775/5000, Loss: 0,0019625639421826106
Epoch 4776/5000, Loss: 0,0019622086201410266
Epoch 4777/5000, Loss: 0,0019618534670842384
Epoch 4778/5000, Loss: 0,0019614984828500623
Epoch 4779/5000, Loss: 0,001961143667276573
Epoch 4780/5000, Loss: 0,0019607890202021122
Epoch 4781/5000, Loss: 0,00196043454146528
Epoch 4782/5000, Loss: 0,0019600802309049383
Epoch 4783/5000, Loss: 0,0019597260883602178
Epoch 4784/5000, Loss: 0,0019593721136705084
Epoch 4785/5000, Loss: 0,0019590183066754657
Epoch 4786/5000, Loss: 0,001958664667215012
Epoch 4787/5000, Loss: 0,0019583111951293327
Epoch 4788/5000, Loss: 0,001957957890258881
Epoch 4789/5000, Loss: 0,001957604752444376
Epoch 4790/5000, Loss: 0,0019572517815268056
Epoch 4791/5000, Loss: 0,001956898977347423
Epoch 4792/5000, Loss: 0,0019565463397477516
Epoch 4793/5000, Loss: 0,0019561938685695823
Epoch 4794/5000, Loss: 0,001955841563654977
Epoch 4795/5000, Loss: 0,0019554894248462657
Epoch 4796/5000, Loss: 0,0019551374519860476
Epoch 4797/5000, Loss: 0,001954785644917196
Epoch 4798/5000, Loss: 0,0019544340034828556
Epoch 4799/5000, Loss: 0,0019540825275264372
Epoch 4800/5000, Loss: 0,001953731216891631
Epoch 4801/5000, Loss: 0,001953380071422396
Epoch 4802/5000, Loss: 0,0019530290909629652
Epoch 4803/5000, Loss: 0,0019526782753578457
Epoch 4804/5000, Loss: 0,0019523276244518186
Epoch 4805/5000, Loss: 0,0019519771380899387
Epoch 4806/5000, Loss: 0,001951626816117539
Epoch 4807/5000, Loss: 0,0019512766583802254
Epoch 4808/5000, Loss: 0,001950926664723881
Epoch 4809/5000, Loss: 0,0019505768349946644
Epoch 4810/5000, Loss: 0,001950227169039012
Epoch 4811/5000, Loss: 0,001949877666703638
Epoch 4812/5000, Loss: 0,0019495283278355344
Epoch 4813/5000, Loss: 0,0019491791522819736
Epoch 4814/5000, Loss: 0,0019488301398905023
Epoch 4815/5000, Loss: 0,0019484812905089463
Epoch 4816/5000, Loss: 0,0019481326039854185
Epoch 4817/5000, Loss: 0,0019477840801683047
Epoch 4818/5000, Loss: 0,0019474357189062752
Epoch 4819/5000, Loss: 0,0019470875200482767
Epoch 4820/5000, Loss: 0,0019467394834435416
Epoch 4821/5000, Loss: 0,0019463916089415847
Epoch 4822/5000, Loss: 0,0019460438963921991
Epoch 4823/5000, Loss: 0,0019456963456454643
Epoch 4824/5000, Loss: 0,0019453489565517388
Epoch 4825/5000, Loss: 0,0019450017289616693
Epoch 4826/5000, Loss: 0,0019446546627261813
Epoch 4827/5000, Loss: 0,0019443077576964906
Epoch 4828/5000, Loss: 0,0019439610137240927
Epoch 4829/5000, Loss: 0,0019436144306607707
Epoch 4830/5000, Loss: 0,00194326800835859
Epoch 4831/5000, Loss: 0,001942921746669906
Epoch 4832/5000, Loss: 0,0019425756454473568
Epoch 4833/5000, Loss: 0,0019422297045438703
Epoch 4834/5000, Loss: 0,001941883923812659
Epoch 4835/5000, Loss: 0,0019415383031072212
Epoch 4836/5000, Loss: 0,001941192842281349
Epoch 4837/5000, Loss: 0,0019408475411891155
Epoch 4838/5000, Loss: 0,0019405023996848872
Epoch 4839/5000, Loss: 0,0019401574176233145
Epoch 4840/5000, Loss: 0,0019398125948593425
Epoch 4841/5000, Loss: 0,0019394679312482017
Epoch 4842/5000, Loss: 0,0019391234266454133
Epoch 4843/5000, Loss: 0,0019387790809067915
Epoch 4844/5000, Loss: 0,0019384348938884365
Epoch 4845/5000, Loss: 0,0019380908654467396
Epoch 4846/5000, Loss: 0,0019377469954383892
Epoch 4847/5000, Loss: 0,0019374032837203576
Epoch 4848/5000, Loss: 0,0019370597301499124
Epoch 4849/5000, Loss: 0,001936716334584615
Epoch 4850/5000, Loss: 0,0019363730968823163
Epoch 4851/5000, Loss: 0,0019360300169011604
Epoch 4852/5000, Loss: 0,0019356870944995848
Epoch 4853/5000, Loss: 0,0019353443295363221
Epoch 4854/5000, Loss: 0,001935001721870396
Epoch 4855/5000, Loss: 0,0019346592713611235
Epoch 4856/5000, Loss: 0,0019343169778681204
Epoch 4857/5000, Loss: 0,0019339748412512936
Epoch 4858/5000, Loss: 0,0019336328613708442
Epoch 4859/5000, Loss: 0,0019332910380872692
Epoch 4860/5000, Loss: 0,0019329493712613628
Epoch 4861/5000, Loss: 0,0019326078607542138
Epoch 4862/5000, Loss: 0,0019322665064272048
Epoch 4863/5000, Loss: 0,0019319253081420175
Epoch 4864/5000, Loss: 0,0019315842657606276
Epoch 4865/5000, Loss: 0,0019312433791453122
Epoch 4866/5000, Loss: 0,0019309026481586396
Epoch 4867/5000, Loss: 0,0019305620726634797
Epoch 4868/5000, Loss: 0,0019302216525229961
Epoch 4869/5000, Loss: 0,0019298813876006537
Epoch 4870/5000, Loss: 0,0019295412777602134
Epoch 4871/5000, Loss: 0,0019292013228657378
Epoch 4872/5000, Loss: 0,0019288615227815824
Epoch 4873/5000, Loss: 0,001928521877372403
Epoch 4874/5000, Loss: 0,0019281823865031594
Epoch 4875/5000, Loss: 0,0019278430500391055
Epoch 4876/5000, Loss: 0,0019275038678457962
Epoch 4877/5000, Loss: 0,0019271648397890845
Epoch 4878/5000, Loss: 0,001926825965735128
Epoch 4879/5000, Loss: 0,0019264872455503803
Epoch 4880/5000, Loss: 0,0019261486791015928
Epoch 4881/5000, Loss: 0,0019258102662558251
Epoch 4882/5000, Loss: 0,0019254720068804336
Epoch 4883/5000, Loss: 0,0019251339008430734
Epoch 4884/5000, Loss: 0,0019247959480117028
Epoch 4885/5000, Loss: 0,0019244581482545826
Epoch 4886/5000, Loss: 0,0019241205014402744
Epoch 4887/5000, Loss: 0,0019237830074376426
Epoch 4888/5000, Loss: 0,0019234456661158471
Epoch 4889/5000, Loss: 0,001923108477344361
Epoch 4890/5000, Loss: 0,0019227714409929524
Epoch 4891/5000, Loss: 0,001922434556931692
Epoch 4892/5000, Loss: 0,0019220978250309533
Epoch 4893/5000, Loss: 0,001921761245161417
Epoch 4894/5000, Loss: 0,0019214248171940632
Epoch 4895/5000, Loss: 0,0019210885410001718
Epoch 4896/5000, Loss: 0,0019207524164513352
Epoch 4897/5000, Loss: 0,0019204164434194417
Epoch 4898/5000, Loss: 0,0019200806217766857
Epoch 4899/5000, Loss: 0,0019197449513955647
Epoch 4900/5000, Loss: 0,0019194094321488824
Epoch 4901/5000, Loss: 0,0019190740639097442
Epoch 4902/5000, Loss: 0,00191873884655156
Epoch 4903/5000, Loss: 0,0019184037799480469
Epoch 4904/5000, Loss: 0,0019180688639732226
Epoch 4905/5000, Loss: 0,0019177340985014116
Epoch 4906/5000, Loss: 0,0019173994834072426
Epoch 4907/5000, Loss: 0,0019170650185656505
Epoch 4908/5000, Loss: 0,0019167307038518739
Epoch 4909/5000, Loss: 0,0019163965391414562
Epoch 4910/5000, Loss: 0,0019160625243102483
Epoch 4911/5000, Loss: 0,0019157286592344069
Epoch 4912/5000, Loss: 0,0019153949437903876
Epoch 4913/5000, Loss: 0,0019150613778549604
Epoch 4914/5000, Loss: 0,001914727961305197
Epoch 4915/5000, Loss: 0,0019143946940184723
Epoch 4916/5000, Loss: 0,001914061575872474
Epoch 4917/5000, Loss: 0,0019137286067451899
Epoch 4918/5000, Loss: 0,0019133957865149179
Epoch 4919/5000, Loss: 0,0019130631150602571
Epoch 4920/5000, Loss: 0,0019127305922601186
Epoch 4921/5000, Loss: 0,0019123982179937177
Epoch 4922/5000, Loss: 0,0019120659921405738
Epoch 4923/5000, Loss: 0,001911733914580517
Epoch 4924/5000, Loss: 0,0019114019851936815
Epoch 4925/5000, Loss: 0,0019110702038605113
Epoch 4926/5000, Loss: 0,0019107385704617498
Epoch 4927/5000, Loss: 0,0019104070848784554
Epoch 4928/5000, Loss: 0,0019100757469919939
Epoch 4929/5000, Loss: 0,0019097445566840288
Epoch 4930/5000, Loss: 0,0019094135138365367
Epoch 4931/5000, Loss: 0,0019090826183318064
Epoch 4932/5000, Loss: 0,0019087518700524244
Epoch 4933/5000, Loss: 0,0019084212688812874
Epoch 4934/5000, Loss: 0,0019080908147016055
Epoch 4935/5000, Loss: 0,0019077605073968902
Epoch 4936/5000, Loss: 0,0019074303468509571
Epoch 4937/5000, Loss: 0,001907100332947936
Epoch 4938/5000, Loss: 0,001906770465572265
Epoch 4939/5000, Loss: 0,0019064407446086837
Epoch 4940/5000, Loss: 0,001906111169942239
Epoch 4941/5000, Loss: 0,0019057817414582917
Epoch 4942/5000, Loss: 0,0019054524590425078
Epoch 4943/5000, Loss: 0,0019051233225808567
Epoch 4944/5000, Loss: 0,0019047943319596204
Epoch 4945/5000, Loss: 0,0019044654870653862
Epoch 4946/5000, Loss: 0,0019041367877850502
Epoch 4947/5000, Loss: 0,0019038082340058118
Epoch 4948/5000, Loss: 0,0019034798256151852
Epoch 4949/5000, Loss: 0,0019031515625009903
Epoch 4950/5000, Loss: 0,0019028234445513503
Epoch 4951/5000, Loss: 0,0019024954716546968
Epoch 4952/5000, Loss: 0,0019021676436997749
Epoch 4953/5000, Loss: 0,001901839960575634
Epoch 4954/5000, Loss: 0,001901512422171628
Epoch 4955/5000, Loss: 0,0019011850283774205
Epoch 4956/5000, Loss: 0,0019008577790829858
Epoch 4957/5000, Loss: 0,001900530674178604
Epoch 4958/5000, Loss: 0,0019002037135548593
Epoch 4959/5000, Loss: 0,0018998768971026478
Epoch 4960/5000, Loss: 0,0018995502247131709
Epoch 4961/5000, Loss: 0,0018992236962779396
Epoch 4962/5000, Loss: 0,00189889731168877
Epoch 4963/5000, Loss: 0,001898571070837788
Epoch 4964/5000, Loss: 0,0018982449736174231
Epoch 4965/5000, Loss: 0,0018979190199204163
Epoch 4966/5000, Loss: 0,0018975932096398141
Epoch 4967/5000, Loss: 0,0018972675426689699
Epoch 4968/5000, Loss: 0,001896942018901545
Epoch 4969/5000, Loss: 0,0018966166382315091
Epoch 4970/5000, Loss: 0,0018962914005531365
Epoch 4971/5000, Loss: 0,0018959663057610092
Epoch 4972/5000, Loss: 0,001895641353750016
Epoch 4973/5000, Loss: 0,0018953165444153576
Epoch 4974/5000, Loss: 0,0018949918776525357
Epoch 4975/5000, Loss: 0,0018946673533573575
Epoch 4976/5000, Loss: 0,0018943429714259428
Epoch 4977/5000, Loss: 0,0018940187317547166
Epoch 4978/5000, Loss: 0,0018936946342404067
Epoch 4979/5000, Loss: 0,0018933706787800503
Epoch 4980/5000, Loss: 0,001893046865270993
Epoch 4981/5000, Loss: 0,001892723193610887
Epoch 4982/5000, Loss: 0,0018923996636976807
Epoch 4983/5000, Loss: 0,001892076275429641
Epoch 4984/5000, Loss: 0,0018917530287053403
Epoch 4985/5000, Loss: 0,0018914299234236494
Epoch 4986/5000, Loss: 0,0018911069594837455
Epoch 4987/5000, Loss: 0,0018907841367851214
Epoch 4988/5000, Loss: 0,0018904614552275674
Epoch 4989/5000, Loss: 0,00189013891471118
Epoch 4990/5000, Loss: 0,0018898165151363636
Epoch 4991/5000, Loss: 0,0018894942564038283
Epoch 4992/5000, Loss: 0,0018891721384145892
Epoch 4993/5000, Loss: 0,0018888501610699626
Epoch 4994/5000, Loss: 0,0018885283242715753
Epoch 4995/5000, Loss: 0,00188820662792136
Epoch 4996/5000, Loss: 0,0018878850719215479
Epoch 4997/5000, Loss: 0,001887563656174676
Epoch 4998/5000, Loss: 0,0018872423805835962
Epoch 4999/5000, Loss: 0,0018869212450514563
Epoch 5000/5000, Loss: 0,0018866002494817018
Testing trained RNN on physics sentences:
Input: energy cannot be created or destroyed only transformed
Predicted: cannot be created or destroyed only transformed

Input: an object in motion stays in motion unless acted upon by external force
Predicted: object in motion stays in motion unless acted upon by external force

Input: the speed of light in vacuum is a fundamental constant of nature
Predicted: speed of light in vacuum is a fundamental constant of nature

Input: electrons occupy discrete energy levels around the nucleus of an atom
Predicted: occupy discrete energy levels around the nucleus of an atom

Input: gravitational force between two masses is directly proportional to their product and inversely proportional to square of distance
Predicted: force between two masses is directly proportional to square product and inversely proportional to square of distance

Input: ice age
Predicted: inversely proportional is of

Input: proton has
Predicted: of angular of to
             */

            //int hiddenSize = 150;
            //double learningRate = 0.001;
            //int epochs = 10000;
            /*
             Epoch 9957/10000, Loss: 0,012709134731470607
Epoch 9958/10000, Loss: 0,012709011854697893
Epoch 9959/10000, Loss: 0,012709202417309839
Epoch 9960/10000, Loss: 0,01270907956331667
Epoch 9961/10000, Loss: 0,012709269985503136
Epoch 9962/10000, Loss: 0,012709147154344392
Epoch 9963/10000, Loss: 0,01270933743636167
Epoch 9964/10000, Loss: 0,012709214628091919
Epoch 9965/10000, Loss: 0,012709404770195531
Epoch 9966/10000, Loss: 0,012709281984868998
Epoch 9967/10000, Loss: 0,012709471987313694
Epoch 9968/10000, Loss: 0,012709349224984273
Epoch 9969/10000, Loss: 0,012709539088024035
Epoch 9970/10000, Loss: 0,012709416348745292
Epoch 9971/10000, Loss: 0,012709606072633347
Epoch 9972/10000, Loss: 0,012709483356458514
Epoch 9973/10000, Loss: 0,012709672941447342
Epoch 9974/10000, Loss: 0,012709550248429333
Epoch 9975/10000, Loss: 0,012709739694770633
Epoch 9976/10000, Loss: 0,012709617024962021
Epoch 9977/10000, Loss: 0,012709806332906767
Epoch 9978/10000, Loss: 0,012709683686359819
Epoch 9979/10000, Loss: 0,012709872856158221
Epoch 9980/10000, Loss: 0,012709750232924866
Epoch 9981/10000, Loss: 0,0127099392648264
Epoch 9982/10000, Loss: 0,01270981666495824
Epoch 9983/10000, Loss: 0,012710005559211642
Epoch 9984/10000, Loss: 0,012709882982759985
Epoch 9985/10000, Loss: 0,012710071739613235
Epoch 9986/10000, Loss: 0,012709949186629061
Epoch 9987/10000, Loss: 0,012710137806329413
Epoch 9988/10000, Loss: 0,012710015276863374
Epoch 9989/10000, Loss: 0,012710203759657368
Epoch 9990/10000, Loss: 0,012710081253759808
Epoch 9991/10000, Loss: 0,01271026959989322
Epoch 9992/10000, Loss: 0,012710147117614187
Epoch 9993/10000, Loss: 0,012710335327332086
Epoch 9994/10000, Loss: 0,012710212868721297
Epoch 9995/10000, Loss: 0,012710400942268024
Epoch 9996/10000, Loss: 0,012710278507374889
Epoch 9997/10000, Loss: 0,012710466444994064
Epoch 9998/10000, Loss: 0,012710344033867699
Epoch 9999/10000, Loss: 0,01271053183580223
Epoch 10000/10000, Loss: 0,01271040944849143
Testing trained RNN on physics sentences:
Input: energy cannot be created or destroyed only transformed
Predicted: of distance of distance of distance of

Input: an object in motion stays in motion unless acted upon by external force
Predicted: distance of distance of distance of distance of distance of distance of

Input: the speed of light in vacuum is a fundamental constant of nature
Predicted: distance of distance of distance of distance of distance of distance

Input: electrons occupy discrete energy levels around the nucleus of an atom
Predicted: of distance of distance of distance of distance of distance

Input: gravitational force between two masses is directly proportional to their product and inversely proportional to square of distance
Predicted: of distance of distance of distance of distance of distance of distance of distance of distance of

Input: ice age
Predicted: distance of distance of

Input: proton has
Predicted: distance of distance of
             */

            //int hiddenSize = 150;
            //double learningRate = 0.0001;
            //int epochs = 100000;
            /*
            Epoch 99967/100000, Loss: 0,010910194719862851
            Epoch 99968/100000, Loss: 0,010910355855846113
            Epoch 99969/100000, Loss: 0,01091020030186069
            Epoch 99970/100000, Loss: 0,010910361416277135
            Epoch 99971/100000, Loss: 0,010910205882920273
            Epoch 99972/100000, Loss: 0,010910366975774433
            Epoch 99973/100000, Loss: 0,01091021146304184
            Epoch 99974/100000, Loss: 0,01091037253433824
            Epoch 99975/100000, Loss: 0,010910217042225624
            Epoch 99976/100000, Loss: 0,010910378091968789
            Epoch 99977/100000, Loss: 0,010910222620471869
            Epoch 99978/100000, Loss: 0,010910383648666321
            Epoch 99979/100000, Loss: 0,010910228197780815
            Epoch 99980/100000, Loss: 0,010910389204431072
            Epoch 99981/100000, Loss: 0,010910233774152693
            Epoch 99982/100000, Loss: 0,010910394759263285
            Epoch 99983/100000, Loss: 0,010910239349587748
            Epoch 99984/100000, Loss: 0,01091040031316319
            Epoch 99985/100000, Loss: 0,01091024492408622
            Epoch 99986/100000, Loss: 0,01091040586613103
            Epoch 99987/100000, Loss: 0,010910250497648342
            Epoch 99988/100000, Loss: 0,01091041141816704
            Epoch 99989/100000, Loss: 0,010910256070274356
            Epoch 99990/100000, Loss: 0,010910416969271456
            Epoch 99991/100000, Loss: 0,010910261641964498
            Epoch 99992/100000, Loss: 0,010910422519444513
            Epoch 99993/100000, Loss: 0,010910267212719009
            Epoch 99994/100000, Loss: 0,010910428068686456
            Epoch 99995/100000, Loss: 0,01091027278253812
            Epoch 99996/100000, Loss: 0,010910433616997514
            Epoch 99997/100000, Loss: 0,010910278351422081
            Epoch 99998/100000, Loss: 0,010910439164377927
            Epoch 99999/100000, Loss: 0,010910283919371119
            Epoch 100000/100000, Loss: 0,010910444710827926
            Testing trained RNN on physics sentences:
            Input: energy cannot be created or destroyed only transformed
            Predicted: same same same same same which same

            Input: an object in motion stays in motion unless acted upon by external force
            Predicted: which same which same which same which same same same same same

            Input: the speed of light in vacuum is a fundamental constant of nature
            Predicted: same same which same which same which same same same which

            Input: electrons occupy discrete energy levels around the nucleus of an atom
            Predicted: same same same same same which same same same which

            Input: gravitational force between two masses is directly proportional to their product and inversely proportional to square of distance
            Predicted: same which same which same which same which same same same which same which same which same

            Input: ice age
            Predicted: which same which same

            Input: proton has
            Predicted: which same which same
            */

            #region hiddenSize 300

            //int hiddenSize = 300;
            //double learningRate = 0.0001;
            //int epochs = 10000;
            /*
            Epoch 9974/10000, Loss: 0,005638012895492045
            Epoch 9975/10000, Loss: 0,005637640255126275
            Epoch 9976/10000, Loss: 0,0056372676512712995
            Epoch 9977/10000, Loss: 0,00563689508392338
            Epoch 9978/10000, Loss: 0,0056365225530787865
            Epoch 9979/10000, Loss: 0,0056361500587337795
            Epoch 9980/10000, Loss: 0,0056357776008846274
            Epoch 9981/10000, Loss: 0,005635405179527592
            Epoch 9982/10000, Loss: 0,005635032794658944
            Epoch 9983/10000, Loss: 0,005634660446274948
            Epoch 9984/10000, Loss: 0,005634288134371871
            Epoch 9985/10000, Loss: 0,0056339158589459775
            Epoch 9986/10000, Loss: 0,005633543619993536
            Epoch 9987/10000, Loss: 0,0056331714175108126
            Epoch 9988/10000, Loss: 0,00563279925149408
            Epoch 9989/10000, Loss: 0,005632427121939601
            Epoch 9990/10000, Loss: 0,005632055028843642
            Epoch 9991/10000, Loss: 0,005631682972202476
            Epoch 9992/10000, Loss: 0,005631310952012371
            Epoch 9993/10000, Loss: 0,005630938968269597
            Epoch 9994/10000, Loss: 0,005630567020970417
            Epoch 9995/10000, Loss: 0,005630195110111105
            Epoch 9996/10000, Loss: 0,005629823235687932
            Epoch 9997/10000, Loss: 0,005629451397697166
            Epoch 9998/10000, Loss: 0,005629079596135075
            Epoch 9999/10000, Loss: 0,005628707830997932
            Epoch 10000/10000, Loss: 0,00562833610228201
            Testing trained RNN on physics sentences:
            Input: energy cannot be created or destroyed only transformed
            Predicted: cannot be created or destroyed only same

            Input: an object in motion stays in motion unless acted upon by external force
            Predicted: object in motion unless in motion unless be upon by external force

            Input: the speed of light in vacuum is a fundamental constant of nature
            Predicted: speed of light in motion is a fundamental constant of of

            Input: electrons occupy discrete energy levels around the nucleus of an atom
            Predicted: occupy discrete energy levels around the the of an atom

            Input: gravitational force between two masses is directly proportional to their product and inversely proportional to square of distance
            Predicted: force between two masses is which proportional to their product and which proportional to square of of

            Input: ice age
            Predicted: this which which same

            Input: proton has
            Predicted: of which same same
            */


            //int hiddenSize = 300;
            //double learningRate = 0.0001;
            //int epochs = 20000;
            /*
            Epoch 19915/20000, Loss: 0,0031857163320343903
            Epoch 19916/20000, Loss: 0,003185558120638199
            Epoch 19917/20000, Loss: 0,0031853999224840863
            Epoch 19918/20000, Loss: 0,003185241737570571
            Epoch 19919/20000, Loss: 0,0031850835658961745
            Epoch 19920/20000, Loss: 0,003184925407459414
            Epoch 19921/20000, Loss: 0,00318476726225881
            Epoch 19922/20000, Loss: 0,00318460913029288
            Epoch 19923/20000, Loss: 0,0031844510115601457
            Epoch 19924/20000, Loss: 0,003184292906059123
            Epoch 19925/20000, Loss: 0,0031841348137883383
            Epoch 19926/20000, Loss: 0,003183976734746305
            Epoch 19927/20000, Loss: 0,0031838186689315457
            Epoch 19928/20000, Loss: 0,003183660616342581
            Epoch 19929/20000, Loss: 0,00318350257697793
            Epoch 19930/20000, Loss: 0,0031833445508361114
            Epoch 19931/20000, Loss: 0,003183186537915648
            Epoch 19932/20000, Loss: 0,0031830285382150603
            Epoch 19933/20000, Loss: 0,0031828705517328673
            Epoch 19934/20000, Loss: 0,0031827125784675897
            Epoch 19935/20000, Loss: 0,0031825546184177495
            Epoch 19936/20000, Loss: 0,003182396671581865
            Epoch 19937/20000, Loss: 0,003182238737958461
            Epoch 19938/20000, Loss: 0,003182080817546059
            Epoch 19939/20000, Loss: 0,0031819229103431726
            Epoch 19940/20000, Loss: 0,003181765016348332
            Epoch 19941/20000, Loss: 0,0031816071355600544
            Epoch 19942/20000, Loss: 0,003181449267976861
            Epoch 19943/20000, Loss: 0,0031812914135972746
            Epoch 19944/20000, Loss: 0,003181133572419819
            Epoch 19945/20000, Loss: 0,0031809757444430107
            Epoch 19946/20000, Loss: 0,0031808179296653758
            Epoch 19947/20000, Loss: 0,0031806601280854343
            Epoch 19948/20000, Loss: 0,0031805023397017095
            Epoch 19949/20000, Loss: 0,003180344564512725
            Epoch 19950/20000, Loss: 0,003180186802517
            Epoch 19951/20000, Loss: 0,00318002905371306
            Epoch 19952/20000, Loss: 0,003179871318099424
            Epoch 19953/20000, Loss: 0,003179713595674619
            Epoch 19954/20000, Loss: 0,0031795558864371647
            Epoch 19955/20000, Loss: 0,0031793981903855844
            Epoch 19956/20000, Loss: 0,0031792405075184013
            Epoch 19957/20000, Loss: 0,00317908283783414
            Epoch 19958/20000, Loss: 0,003178925181331323
            Epoch 19959/20000, Loss: 0,0031787675380084723
            Epoch 19960/20000, Loss: 0,0031786099078641127
            Epoch 19961/20000, Loss: 0,003178452290896768
            Epoch 19962/20000, Loss: 0,0031782946871049605
            Epoch 19963/20000, Loss: 0,003178137096487216
            Epoch 19964/20000, Loss: 0,0031779795190420546
            Epoch 19965/20000, Loss: 0,003177821954768004
            Epoch 19966/20000, Loss: 0,003177664403663589
            Epoch 19967/20000, Loss: 0,0031775068657273293
            Epoch 19968/20000, Loss: 0,0031773493409577537
            Epoch 19969/20000, Loss: 0,003177191829353384
            Epoch 19970/20000, Loss: 0,003177034330912746
            Epoch 19971/20000, Loss: 0,0031768768456343632
            Epoch 19972/20000, Loss: 0,0031767193735167615
            Epoch 19973/20000, Loss: 0,003176561914558465
            Epoch 19974/20000, Loss: 0,0031764044687579993
            Epoch 19975/20000, Loss: 0,0031762470361138885
            Epoch 19976/20000, Loss: 0,0031760896166246584
            Epoch 19977/20000, Loss: 0,0031759322102888356
            Epoch 19978/20000, Loss: 0,003175774817104943
            Epoch 19979/20000, Loss: 0,0031756174370715074
            Epoch 19980/20000, Loss: 0,0031754600701870543
            Epoch 19981/20000, Loss: 0,003175302716450111
            Epoch 19982/20000, Loss: 0,0031751453758591995
            Epoch 19983/20000, Loss: 0,0031749880484128494
            Epoch 19984/20000, Loss: 0,0031748307341095865
            Epoch 19985/20000, Loss: 0,003174673432947933
            Epoch 19986/20000, Loss: 0,0031745161449264216
            Epoch 19987/20000, Loss: 0,0031743588700435727
            Epoch 19988/20000, Loss: 0,003174201608297917
            Epoch 19989/20000, Loss: 0,003174044359687979
            Epoch 19990/20000, Loss: 0,0031738871242122852
            Epoch 19991/20000, Loss: 0,0031737299018693627
            Epoch 19992/20000, Loss: 0,003173572692657739
            Epoch 19993/20000, Loss: 0,003173415496575941
            Epoch 19994/20000, Loss: 0,0031732583136224964
            Epoch 19995/20000, Loss: 0,0031731011437959324
            Epoch 19996/20000, Loss: 0,003172943987094776
            Epoch 19997/20000, Loss: 0,003172786843517552
            Epoch 19998/20000, Loss: 0,0031726297130627917
            Epoch 19999/20000, Loss: 0,0031724725957290234
            Epoch 20000/20000, Loss: 0,003172315491514771
            Testing trained RNN on physics sentences:
            Input: energy cannot be created or destroyed only transformed
            Predicted: cannot be created or destroyed only transformed

            Input: an object in motion stays in motion unless acted upon by external force
            Predicted: object in motion stays in motion unless acted upon by external force

            Input: the speed of light in vacuum is a fundamental constant of nature
            Predicted: speed of light in motion is a fundamental constant of nature

            Input: electrons occupy discrete energy levels around the nucleus of an atom
            Predicted: occupy discrete energy levels around the nucleus of an atom

            Input: gravitational force between two masses is directly proportional to their product and inversely proportional to square of distance
            Predicted: force between two masses is which proportional to their product and inversely proportional to square of distance

            Input: ice age
            Predicted: is proportional to same

            Input: proton has
            Predicted: of same hence to
            */


            //int hiddenSize = 300;
            //double learningRate = 0.0001;
            //int epochs = 30000;
            /*
            Epoch 29965/30000, Loss: 0,002161914184817159
            Epoch 29966/30000, Loss: 0,0021618428962502934
            Epoch 29967/30000, Loss: 0,00216177161207324
            Epoch 29968/30000, Loss: 0,0021617003322855683
            Epoch 29969/30000, Loss: 0,002161629056886842
            Epoch 29970/30000, Loss: 0,0021615577858766282
            Epoch 29971/30000, Loss: 0,002161486519254488
            Epoch 29972/30000, Loss: 0,0021614152570199924
            Epoch 29973/30000, Loss: 0,0021613439991727047
            Epoch 29974/30000, Loss: 0,002161272745712189
            Epoch 29975/30000, Loss: 0,0021612014966380156
            Epoch 29976/30000, Loss: 0,002161130251949746
            Epoch 29977/30000, Loss: 0,002161059011646949
            Epoch 29978/30000, Loss: 0,002160987775729188
            Epoch 29979/30000, Loss: 0,0021609165441960313
            Epoch 29980/30000, Loss: 0,0021608453170470446
            Epoch 29981/30000, Loss: 0,002160774094281794
            Epoch 29982/30000, Loss: 0,0021607028758998466
            Epoch 29983/30000, Loss: 0,0021606316619007674
            Epoch 29984/30000, Loss: 0,002160560452284124
            Epoch 29985/30000, Loss: 0,002160489247049481
            Epoch 29986/30000, Loss: 0,002160418046196408
            Epoch 29987/30000, Loss: 0,0021603468497244692
            Epoch 29988/30000, Loss: 0,0021602756576332323
            Epoch 29989/30000, Loss: 0,002160204469922264
            Epoch 29990/30000, Loss: 0,0021601332865911317
            Epoch 29991/30000, Loss: 0,0021600621076394017
            Epoch 29992/30000, Loss: 0,0021599909330666414
            Epoch 29993/30000, Loss: 0,0021599197628724186
            Epoch 29994/30000, Loss: 0,0021598485970562983
            Epoch 29995/30000, Loss: 0,0021597774356178494
            Epoch 29996/30000, Loss: 0,0021597062785566395
            Epoch 29997/30000, Loss: 0,0021596351258722337
            Epoch 29998/30000, Loss: 0,0021595639775642034
            Epoch 29999/30000, Loss: 0,002159492833632111
            Epoch 30000/30000, Loss: 0,0021594216940755283
            Testing trained RNN on physics sentences:
            Input: energy cannot be created or destroyed only transformed
            Predicted: cannot be created or destroyed only transformed

            Input: an object in motion stays in motion unless acted upon by external force
            Predicted: object in motion stays in motion unless acted upon by external force

            Input: the speed of light in vacuum is a fundamental constant of nature
            Predicted: speed of light in vacuum is a fundamental constant of nature

            Input: electrons occupy discrete energy levels around the nucleus of an atom
            Predicted: occupy discrete energy levels around the nucleus of an atom

            Input: gravitational force between two masses is directly proportional to their product and inversely proportional to square of distance
            Predicted: force between two masses is directly proportional to their product and inversely proportional to square of distance

            Input: ice age
            Predicted: is proportional to same

            Input: proton has
            Predicted: of discrete energy to
            */


            //int hiddenSize = 300;
            //double learningRate = 0.0001;
            //int epochs = 40000;
            /*
            Epoch 39963/40000, Loss: 0,0016433228638859077
            Epoch 39964/40000, Loss: 0,0016432849183041509
            Epoch 39965/40000, Loss: 0,0016432469749497196
            Epoch 39966/40000, Loss: 0,0016432090338223358
            Epoch 39967/40000, Loss: 0,0016431710949217164
            Epoch 39968/40000, Loss: 0,0016431331582475843
            Epoch 39969/40000, Loss: 0,0016430952237996561
            Epoch 39970/40000, Loss: 0,0016430572915776549
            Epoch 39971/40000, Loss: 0,0016430193615812982
            Epoch 39972/40000, Loss: 0,0016429814338103077
            Epoch 39973/40000, Loss: 0,0016429435082644008
            Epoch 39974/40000, Loss: 0,0016429055849432987
            Epoch 39975/40000, Loss: 0,0016428676638467205
            Epoch 39976/40000, Loss: 0,0016428297449743875
            Epoch 39977/40000, Loss: 0,0016427918283260189
            Epoch 39978/40000, Loss: 0,001642753913901334
            Epoch 39979/40000, Loss: 0,0016427160017000529
            Epoch 39980/40000, Loss: 0,001642678091721896
            Epoch 39981/40000, Loss: 0,0016426401839665834
            Epoch 39982/40000, Loss: 0,0016426022784338337
            Epoch 39983/40000, Loss: 0,0016425643751233686
            Epoch 39984/40000, Loss: 0,0016425264740349069
            Epoch 39985/40000, Loss: 0,0016424885751681688
            Epoch 39986/40000, Loss: 0,0016424506785228758
            Epoch 39987/40000, Loss: 0,0016424127840987447
            Epoch 39988/40000, Loss: 0,001642374891895498
            Epoch 39989/40000, Loss: 0,0016423370019128555
            Epoch 39990/40000, Loss: 0,0016422991141505365
            Epoch 39991/40000, Loss: 0,0016422612286082611
            Epoch 39992/40000, Loss: 0,001642223345285751
            Epoch 39993/40000, Loss: 0,001642185464182724
            Epoch 39994/40000, Loss: 0,0016421475852989018
            Epoch 39995/40000, Loss: 0,0016421097086340042
            Epoch 39996/40000, Loss: 0,0016420718341877516
            Epoch 39997/40000, Loss: 0,0016420339619598625
            Epoch 39998/40000, Loss: 0,001641996091950059
            Epoch 39999/40000, Loss: 0,0016419582241580604
            Epoch 40000/40000, Loss: 0,0016419203585835874
            Testing trained RNN on physics sentences:
            Input: energy cannot be created or destroyed only transformed
            Predicted: cannot be created or destroyed only transformed

            Input: an object in motion stays in motion unless acted upon by external force
            Predicted: object in motion stays in motion unless acted upon by external force

            Input: the speed of light in vacuum is a fundamental constant of nature
            Predicted: speed of light in vacuum is a fundamental constant of nature

            Input: electrons occupy discrete energy levels around the nucleus of an atom
            Predicted: occupy discrete energy levels around the nucleus of an atom

            Input: gravitational force between two masses is directly proportional to their product and inversely proportional to square of distance
            Predicted: force between two masses is directly proportional to their product and inversely proportional to square of distance

            Input: ice age
            Predicted: only therefore is same

            Input: proton has
            Predicted: of cannot all to
            */


            //int hiddenSize = 300;
            //double learningRate = 0.0001;
            //int epochs = 50000;
            /*
            Epoch 49957/50000, Loss: 0,0013594680963557918
            Epoch 49958/50000, Loss: 0,0013594388345486465
            Epoch 49959/50000, Loss: 0,001359409574773073
            Epoch 49960/50000, Loss: 0,0013593803171569035
            Epoch 49961/50000, Loss: 0,0013593510618275548
            Epoch 49962/50000, Loss: 0,00135932180891202
            Epoch 49963/50000, Loss: 0,0013592925585368737
            Epoch 49964/50000, Loss: 0,001359263310828268
            Epoch 49965/50000, Loss: 0,0013592340659119336
            Epoch 49966/50000, Loss: 0,0013592048239131672
            Epoch 49967/50000, Loss: 0,0013591755849568464
            Epoch 49968/50000, Loss: 0,0013591463491674123
            Epoch 49969/50000, Loss: 0,001359117116668882
            Epoch 49970/50000, Loss: 0,0013590878875848343
            Epoch 49971/50000, Loss: 0,0013590586620384172
            Epoch 49972/50000, Loss: 0,001359029440152339
            Epoch 49973/50000, Loss: 0,001359000222048877
            Epoch 49974/50000, Loss: 0,0013589710078498703
            Epoch 49975/50000, Loss: 0,0013589417976767114
            Epoch 49976/50000, Loss: 0,0013589125916503536
            Epoch 49977/50000, Loss: 0,0013588833898913158
            Epoch 49978/50000, Loss: 0,001358854192519668
            Epoch 49979/50000, Loss: 0,0013588249996550317
            Epoch 49980/50000, Loss: 0,0013587958114165868
            Epoch 49981/50000, Loss: 0,0013587666279230685
            Epoch 49982/50000, Loss: 0,001358737449292765
            Epoch 49983/50000, Loss: 0,0013587082756435043
            Epoch 49984/50000, Loss: 0,0013586791070926754
            Epoch 49985/50000, Loss: 0,0013586499437572182
            Epoch 49986/50000, Loss: 0,0013586207857536122
            Epoch 49987/50000, Loss: 0,001358591633197884
            Epoch 49988/50000, Loss: 0,0013585624862056168
            Epoch 49989/50000, Loss: 0,0013585333448919343
            Epoch 49990/50000, Loss: 0,0013585042093714997
            Epoch 49991/50000, Loss: 0,0013584750797585245
            Epoch 49992/50000, Loss: 0,0013584459561667688
            Epoch 49993/50000, Loss: 0,0013584168387095294
            Epoch 49994/50000, Loss: 0,0013583877274996451
            Epoch 49995/50000, Loss: 0,0013583586226494986
            Epoch 49996/50000, Loss: 0,0013583295242710143
            Epoch 49997/50000, Loss: 0,001358300432475658
            Epoch 49998/50000, Loss: 0,0013582713473744286
            Epoch 49999/50000, Loss: 0,0013582422690778743
            Epoch 50000/50000, Loss: 0,0013582131976960798
            Testing trained RNN on physics sentences:
            Input: energy cannot be created or destroyed only transformed
            Predicted: cannot be created or destroyed only transformed

            Input: an object in motion stays in motion unless acted upon by external force
            Predicted: object in motion stays in motion unless acted upon by external force

            Input: the speed of light in vacuum is a fundamental constant of nature
            Predicted: speed of light in vacuum is a fundamental constant of nature

            Input: electrons occupy discrete energy levels around the nucleus of an atom
            Predicted: occupy discrete energy levels around the nucleus of an atom

            Input: gravitational force between two masses is directly proportional to their product and inversely proportional to square of distance
            Predicted: force between two masses is directly proportional to their product and inversely proportional to square of distance

            Input: ice age
            Predicted: inversely proportional is same

            Input: proton has
            Predicted: of distance of motion
            */


            //int hiddenSize = 300;
            //double learningRate = 0.0001;
            //int epochs = 60000;
            /*
            Epoch 59865/60000, Loss: 0,009293218794530392
            Epoch 59866/60000, Loss: 0,00929539372825467
            Epoch 59867/60000, Loss: 0,009295972272483712
            Epoch 59868/60000, Loss: 0,009298141413424913
            Epoch 59869/60000, Loss: 0,009298721214469481
            Epoch 59870/60000, Loss: 0,009300884529097756
            Epoch 59871/60000, Loss: 0,00930146562610479
            Epoch 59872/60000, Loss: 0,009303623080973364
            Epoch 59873/60000, Loss: 0,009304205513033497
            Epoch 59874/60000, Loss: 0,009306357074784766
            Epoch 59875/60000, Loss: 0,009306940880927065
            Epoch 59876/60000, Loss: 0,00930908651629873
            Epoch 59877/60000, Loss: 0,009309671735485364
            Epoch 59878/60000, Loss: 0,009311811411316555
            Epoch 59879/60000, Loss: 0,009312398082437478
            Epoch 59880/60000, Loss: 0,009314531765674946
            Epoch 59881/60000, Loss: 0,009315119927542567
            Epoch 59882/60000, Loss: 0,009317247585246793
            Epoch 59883/60000, Loss: 0,009317837276590541
            Epoch 59884/60000, Loss: 0,009319958875941947
            Epoch 59885/60000, Loss: 0,00932055013540289
            Epoch 59886/60000, Loss: 0,009322665643707985
            Epoch 59887/60000, Loss: 0,0093232585098334
            Epoch 59888/60000, Loss: 0,00932536789453096
            Epoch 59889/60000, Loss: 0,009325962405768839
            Epoch 59890/60000, Loss: 0,009328065634436115
            Epoch 59891/60000, Loss: 0,009328661829129694
            Epoch 59892/60000, Loss: 0,009330758869488542
            Epoch 59893/60000, Loss: 0,009331356785870808
            Epoch 59894/60000, Loss: 0,009333447605793908
            Epoch 59895/60000, Loss: 0,009334047281982064
            Epoch 59896/60000, Loss: 0,009336131849499071
            Epoch 59897/60000, Loss: 0,009336733323488972
            Epoch 59898/60000, Loss: 0,009338811606792705
            Epoch 59899/60000, Loss: 0,00933941491645331
            Epoch 59900/60000, Loss: 0,009341486883905892
            Epoch 59901/60000, Loss: 0,009342092066973668
            Epoch 59902/60000, Loss: 0,009344157687112694
            Epoch 59903/60000, Loss: 0,009344764781186047
            Epoch 59904/60000, Loss: 0,009346824022730715
            Epoch 59905/60000, Loss: 0,009347433065264348
            Epoch 59906/60000, Loss: 0,009349485897121602
            Epoch 59907/60000, Loss: 0,009350096925420907
            Epoch 59908/60000, Loss: 0,009352143316691543
            Epoch 59909/60000, Loss: 0,009352756367906955
            Epoch 59910/60000, Loss: 0,009354796287891726
            Epoch 59911/60000, Loss: 0,009355411399013077
            Epoch 59912/60000, Loss: 0,009357444817218787
            Epoch 59913/60000, Loss: 0,00935806202506967
            Epoch 59914/60000, Loss: 0,009360088911215212
            Epoch 59915/60000, Loss: 0,009360708252447286
            Epoch 59916/60000, Loss: 0,009362728576469704
            Epoch 59917/60000, Loss: 0,00936335008755706
            Epoch 59918/60000, Loss: 0,009365363819617572
            Epoch 59919/60000, Loss: 0,009365987536851018
            Epoch 59920/60000, Loss: 0,009367994647340989
            Epoch 59921/60000, Loss: 0,00936862060682241
            Epoch 59922/60000, Loss: 0,009370621066369367
            Epoch 59923/60000, Loss: 0,00937124930400602
            Epoch 59924/60000, Loss: 0,009373243083479546
            Epoch 59925/60000, Loss: 0,009373873634978385
            Epoch 59926/60000, Loss: 0,00937586070549606
            Epoch 59927/60000, Loss: 0,009376493606358064
            Epoch 59928/60000, Loss: 0,00937847393929134
            Epoch 59929/60000, Loss: 0,009379109224805827
            Epoch 59930/60000, Loss: 0,009381082791785879
            Epoch 59931/60000, Loss: 0,009381720497024825
            Epoch 59932/60000, Loss: 0,009383687269948374
            Epoch 59933/60000, Loss: 0,00938432742976073
            Epoch 59934/60000, Loss: 0,00938628738079583
            Epoch 59935/60000, Loss: 0,009386930029801885
            Epoch 59936/60000, Loss: 0,009388883131393652
            Epoch 59937/60000, Loss: 0,009389528303979358
            Epoch 59938/60000, Loss: 0,009391474528855668
            Epoch 59939/60000, Loss: 0,009392122259166986
            Epoch 59940/60000, Loss: 0,009394061580344174
            Epoch 59941/60000, Loss: 0,009394711902281434
            Epoch 59942/60000, Loss: 0,009396644293069887
            Epoch 59943/60000, Loss: 0,009397297240282168
            Epoch 59944/60000, Loss: 0,00939922267429192
            Epoch 59945/60000, Loss: 0,00939987828017142
            Epoch 59946/60000, Loss: 0,009401796731317687
            Epoch 59947/60000, Loss: 0,009402455028994134
            Epoch 59948/60000, Loss: 0,009404366471502803
            Epoch 59949/60000, Loss: 0,009405027493837865
            Epoch 59950/60000, Loss: 0,009406931902250908
            Epoch 59951/60000, Loss: 0,009407595681832609
            Epoch 59952/60000, Loss: 0,009409493031013533
            Epoch 59953/60000, Loss: 0,00941015960015072
            Epoch 59954/60000, Loss: 0,009412049865289858
            Epoch 59955/60000, Loss: 0,009412719256006662
            Epoch 59956/60000, Loss: 0,00941460241262648
            Epoch 59957/60000, Loss: 0,0094152746566568
            Epoch 59958/60000, Loss: 0,009417150680617142
            Epoch 59959/60000, Loss: 0,009417825809399146
            Epoch 59960/60000, Loss: 0,009419694676902405
            Epoch 59961/60000, Loss: 0,009420372721573098
            Epoch 59962/60000, Loss: 0,009422234409169337
            Epoch 59963/60000, Loss: 0,00942291540055909
            Epoch 59964/60000, Loss: 0,009424769885151119
            Epoch 59965/60000, Loss: 0,009425453853778258
            Epoch 59966/60000, Loss: 0,009427301112626633
            Epoch 59967/60000, Loss: 0,009427988088692083
            Epoch 59968/60000, Loss: 0,009429828099420057
            Epoch 59969/60000, Loss: 0,009430518112801942
            Epoch 59970/60000, Loss: 0,00943235085340035
            Epoch 59971/60000, Loss: 0,009433043933648706
            Epoch 59972/60000, Loss: 0,009434869382480783
            Epoch 59973/60000, Loss: 0,009435565558812238
            Epoch 59974/60000, Loss: 0,00943738369461839
            Epoch 59975/60000, Loss: 0,009438082995910913
            Epoch 59976/60000, Loss: 0,009439893797813384
            Epoch 59977/60000, Loss: 0,009440596252601078
            Epoch 59978/60000, Loss: 0,009442399700108586
            Epoch 59979/60000, Loss: 0,009443105336576451
            Epoch 59980/60000, Loss: 0,009444901409588759
            Epoch 59981/60000, Loss: 0,009445610255567604
            Epoch 59982/60000, Loss: 0,009447398934379982
            Epoch 59983/60000, Loss: 0,009448111017341249
            Epoch 59984/60000, Loss: 0,009449892282648916
            Epoch 59985/60000, Loss: 0,009450607629699646
            Epoch 59986/60000, Loss: 0,009452381462602067
            Epoch 59987/60000, Loss: 0,00945310010047987
            Epoch 59988/60000, Loss: 0,009454866482485063
            Epoch 59989/60000, Loss: 0,009455588437553116
            Epoch 59990/60000, Loss: 0,009457347350581843
            Epoch 59991/60000, Loss: 0,009458072648823933
            Epoch 59992/60000, Loss: 0,00945982407521381
            Epoch 59993/60000, Loss: 0,00946055274222946
            Epoch 59994/60000, Loss: 0,009462296664738985
            Epoch 59995/60000, Loss: 0,009463028725738603
            Epoch 59996/60000, Loss: 0,009464765127551145
            Epoch 59997/60000, Loss: 0,009465500607351192
            Epoch 59998/60000, Loss: 0,009467229472078864
            Epoch 59999/60000, Loss: 0,009467968395097125
            Epoch 60000/60000, Loss: 0,009469689706784568
            Testing trained RNN on physics sentences:
            Input: energy cannot be created or destroyed only transformed
            Predicted: can same which same which only which

            Input: an object in motion stays in motion unless acted upon by external force
            Predicted: same the which which same which only same same which same which

            Input: the speed of light in vacuum is a fundamental constant of nature
            Predicted: same of same the which this same same same of same

            Input: electrons occupy discrete energy levels around the nucleus of an atom
            Predicted: to same rather same which same same of which same

            Input: gravitational force between two masses is directly proportional to their product and inversely proportional to square of distance
            Predicted: rather same which which this same which which same same which which same which same of same

            Input: ice age
            Predicted: same which same which

            Input: proton has
            Predicted: same which same which
            */

            #endregion


            //int hiddenSize = 900;
            //double learningRate = 0.0001;
            //int epochs = 10000;
            /*
            Epoch 9963/10000, Loss: 0,004138133664121149
            Epoch 9964/10000, Loss: 0,004137795330032954
            Epoch 9965/10000, Loss: 0,004137457037695692
            Epoch 9966/10000, Loss: 0,004137118787102871
            Epoch 9967/10000, Loss: 0,004136780578247997
            Epoch 9968/10000, Loss: 0,004136442411124585
            Epoch 9969/10000, Loss: 0,004136104285726144
            Epoch 9970/10000, Loss: 0,004135766202046186
            Epoch 9971/10000, Loss: 0,004135428160078228
            Epoch 9972/10000, Loss: 0,004135090159815787
            Epoch 9973/10000, Loss: 0,004134752201252374
            Epoch 9974/10000, Loss: 0,004134414284381515
            Epoch 9975/10000, Loss: 0,004134076409196732
            Epoch 9976/10000, Loss: 0,004133738575691543
            Epoch 9977/10000, Loss: 0,004133400783859471
            Epoch 9978/10000, Loss: 0,004133063033694044
            Epoch 9979/10000, Loss: 0,0041327253251887885
            Epoch 9980/10000, Loss: 0,0041323876583372315
            Epoch 9981/10000, Loss: 0,0041320500331329035
            Epoch 9982/10000, Loss: 0,004131712449569336
            Epoch 9983/10000, Loss: 0,004131374907640058
            Epoch 9984/10000, Loss: 0,00413103740733861
            Epoch 9985/10000, Loss: 0,004130699948658521
            Epoch 9986/10000, Loss: 0,004130362531593334
            Epoch 9987/10000, Loss: 0,0041300251561365835
            Epoch 9988/10000, Loss: 0,004129687822281809
            Epoch 9989/10000, Loss: 0,004129350530022556
            Epoch 9990/10000, Loss: 0,004129013279352367
            Epoch 9991/10000, Loss: 0,004128676070264782
            Epoch 9992/10000, Loss: 0,004128338902753352
            Epoch 9993/10000, Loss: 0,004128001776811622
            Epoch 9994/10000, Loss: 0,0041276646924331434
            Epoch 9995/10000, Loss: 0,004127327649611464
            Epoch 9996/10000, Loss: 0,0041269906483401364
            Epoch 9997/10000, Loss: 0,004126653688612715
            Epoch 9998/10000, Loss: 0,004126316770422753
            Epoch 9999/10000, Loss: 0,004125979893763807
            Epoch 10000/10000, Loss: 0,004125643058629437
            Testing trained RNN on physics sentences:
            Input: energy cannot be created or destroyed only transformed
            Predicted: cannot be created or destroyed only transformed

            Input: an object in motion stays in motion unless acted upon by external force
            Predicted: object in motion stays in motion unless acted upon by external force

            Input: the speed of light in vacuum is a fundamental constant of nature
            Predicted: speed of light in motion is a fundamental constant of nature

            Input: electrons occupy discrete energy levels around the nucleus of an atom
            Predicted: occupy discrete energy levels around the nucleus of an atom

            Input: gravitational force between two masses is directly proportional to their product and inversely proportional to square of distance
            Predicted: force between two masses is which proportional to their product and inversely proportional to square of distance

            Input: ice age
            Predicted: of the therefore same

            Input: proton has
            Predicted: of same same same 
            */

            //int hiddenSize = 900;
            //double learningRate = 0.0001;
            //int epochs = 20000;
            /*
            Epoch 17989/20000, Loss: 0,0023654645382839143
            Epoch 17990/20000, Loss: 0,0023653311630254625
            Epoch 17991/20000, Loss: 0,0023651978011940186
            Epoch 17992/20000, Loss: 0,002365064452787682
            Epoch 17993/20000, Loss: 0,002364931117804551
            Epoch 17994/20000, Loss: 0,0023647977962427285
            Epoch 17995/20000, Loss: 0,0023646644881003148
            Epoch 17996/20000, Loss: 0,002364531193375407
            Epoch 17997/20000, Loss: 0,0023643979120661113
            Epoch 17998/20000, Loss: 0,0023642646441705264
            Epoch 17999/20000, Loss: 0,0023641313896867553
            Epoch 18000/20000, Loss: 0,0023639981486128997
            Epoch 18001/20000, Loss: 0,0023638649209470628
            Epoch 18002/20000, Loss: 0,002363731706687347
            Epoch 18003/20000, Loss: 0,0023635985058318544
            Epoch 18004/20000, Loss: 0,0023634653183786936
            Epoch 18005/20000, Loss: 0,002363332144325964
            Epoch 18006/20000, Loss: 0,002363198983671772
            Epoch 18007/20000, Loss: 0,0023630658364142197
            Epoch 18008/20000, Loss: 0,0023629327025514162
            Epoch 18009/20000, Loss: 0,0023627995820814643
            Epoch 18010/20000, Loss: 0,00236266647500247
            Epoch 18011/20000, Loss: 0,0023625333813125393
            Epoch 18012/20000, Loss: 0,002362400301009781
            Epoch 18013/20000, Loss: 0,0023622672340922993
            Epoch 18014/20000, Loss: 0,002362134180558203
            Epoch 18015/20000, Loss: 0,0023620011404055976
            Epoch 18016/20000, Loss: 0,0023618681136325934
            Epoch 18017/20000, Loss: 0,002361735100237298
            Epoch 18018/20000, Loss: 0,0023616021002178197
            Epoch 18019/20000, Loss: 0,002361469113572266
            Epoch 18020/20000, Loss: 0,0023613361402987482
            Epoch 18021/20000, Loss: 0,0023612031803953754
            Epoch 18022/20000, Loss: 0,0023610702338602565
            Epoch 18023/20000, Loss: 0,0023609373006915047
            Epoch 18024/20000, Loss: 0,002360804380887227
            Epoch 18025/20000, Loss: 0,002360671474445537
            Epoch 18026/20000, Loss: 0,0023605385813645447
            Epoch 18027/20000, Loss: 0,002360405701642364
            Epoch 18028/20000, Loss: 0,002360272835277104
            Epoch 18029/20000, Loss: 0,0023601399822668796
            Epoch 18030/20000, Loss: 0,002360007142609801
            Epoch 18031/20000, Loss: 0,0023598743163039835
            Epoch 18032/20000, Loss: 0,002359741503347542
            Epoch 18033/20000, Loss: 0,002359608703738587
            Epoch 18034/20000, Loss: 0,002359475917475232
            Epoch 18035/20000, Loss: 0,002359343144555595
            Epoch 18036/20000, Loss: 0,00235921038497779
            Epoch 18037/20000, Loss: 0,0023590776387399314
            Epoch 18038/20000, Loss: 0,002358944905840134
            Epoch 18039/20000, Loss: 0,0023588121862765173
            Epoch 18040/20000, Loss: 0,002358679480047191
            Epoch 18041/20000, Loss: 0,0023585467871502785
            Epoch 18042/20000, Loss: 0,0023584141075838933
            Epoch 18043/20000, Loss: 0,0023582814413461535
            Epoch 18044/20000, Loss: 0,0023581487884351765
            Epoch 18045/20000, Loss: 0,0023580161488490816
            Epoch 18046/20000, Loss: 0,002357883522585983
            Epoch 18047/20000, Loss: 0,0023577509096440064
            Epoch 18048/20000, Loss: 0,002357618310021264
            Epoch 18049/20000, Loss: 0,002357485723715879
            Epoch 18050/20000, Loss: 0,0023573531507259703
            Epoch 18051/20000, Loss: 0,002357220591049658
            Epoch 18052/20000, Loss: 0,0023570880446850623
            Epoch 18053/20000, Loss: 0,002356955511630305
            Epoch 18054/20000, Loss: 0,0023568229918835056
            Epoch 18055/20000, Loss: 0,0023566904854427874
            Epoch 18056/20000, Loss: 0,0023565579923062714
            Epoch 18057/20000, Loss: 0,0023564255124720783
            Epoch 18058/20000, Loss: 0,0023562930459383345
            Epoch 18059/20000, Loss: 0,0023561605927031586
            Epoch 18060/20000, Loss: 0,002356028152764675
            Epoch 18061/20000, Loss: 0,002355895726121011
            Epoch 18062/20000, Loss: 0,002355763312770285
            Epoch 18063/20000, Loss: 0,0023556309127106254
            Epoch 18064/20000, Loss: 0,0023554985259401544
            Epoch 18065/20000, Loss: 0,002355366152456998
            Epoch 18066/20000, Loss: 0,002355233792259282
            Epoch 18067/20000, Loss: 0,002355101445345132
            Epoch 18068/20000, Loss: 0,0023549691117126723
            Epoch 18069/20000, Loss: 0,0023548367913600325
            Epoch 18070/20000, Loss: 0,002354704484285335
            Epoch 18071/20000, Loss: 0,00235457219048671
            Epoch 18072/20000, Loss: 0,0023544399099622846
            Epoch 18073/20000, Loss: 0,002354307642710185
            Epoch 18074/20000, Loss: 0,0023541753887285416
            Epoch 18075/20000, Loss: 0,0023540431480154815
            Epoch 18076/20000, Loss: 0,002353910920569134
            Epoch 18077/20000, Loss: 0,0023537787063876285
            Epoch 18078/20000, Loss: 0,0023536465054690915
            Epoch 18079/20000, Loss: 0,0023535143178116565
            Epoch 18080/20000, Loss: 0,0023533821434134545
            Epoch 18081/20000, Loss: 0,002353249982272613
            Epoch 18082/20000, Loss: 0,0023531178343872633
            Epoch 18083/20000, Loss: 0,0023529856997555375
            Epoch 18084/20000, Loss: 0,0023528535783755673
            Epoch 18085/20000, Loss: 0,0023527214702454852
            Epoch 18086/20000, Loss: 0,0023525893753634218
            Epoch 18087/20000, Loss: 0,00235245729372751
            Epoch 18088/20000, Loss: 0,0023523252253358855
            Epoch 18089/20000, Loss: 0,002352193170186678
            Epoch 18090/20000, Loss: 0,002352061128278022
            Epoch 18091/20000, Loss: 0,0023519290996080527
            Epoch 18092/20000, Loss: 0,002351797084174905
            Epoch 18093/20000, Loss: 0,0023516650819767125
            Epoch 18094/20000, Loss: 0,0023515330930116113
            Epoch 18095/20000, Loss: 0,002351401117277734
            Epoch 18096/20000, Loss: 0,002351269154773219
            Epoch 18097/20000, Loss: 0,002351137205496201
            Epoch 18098/20000, Loss: 0,0023510052694448204
            Epoch 18099/20000, Loss: 0,0023508733466172083
            Epoch 18100/20000, Loss: 0,002350741437011505
            Epoch 18101/20000, Loss: 0,002350609540625847
            Epoch 18102/20000, Loss: 0,0023504776574583735
            Epoch 18103/20000, Loss: 0,0023503457875072202
            Epoch 18104/20000, Loss: 0,0023502139307705282
            Epoch 18105/20000, Loss: 0,0023500820872464348
            Epoch 18106/20000, Loss: 0,002349950256933081
            Epoch 18107/20000, Loss: 0,0023498184398286046
            Epoch 18108/20000, Loss: 0,0023496866359311456
            Epoch 18109/20000, Loss: 0,0023495548452388453
            Epoch 18110/20000, Loss: 0,0023494230677498446
            Epoch 18111/20000, Loss: 0,002349291303462282
            Epoch 18112/20000, Loss: 0,002349159552374302
            Epoch 18113/20000, Loss: 0,002349027814484044
            Epoch 18114/20000, Loss: 0,0023488960897896515
            Epoch 18115/20000, Loss: 0,0023487643782892655
            Epoch 18116/20000, Loss: 0,00234863267998103
            Epoch 18117/20000, Loss: 0,0023485009948630868
            Epoch 18118/20000, Loss: 0,002348369322933581
            Epoch 18119/20000, Loss: 0,0023482376641906543
            Epoch 18120/20000, Loss: 0,0023481060186324523
            Epoch 18121/20000, Loss: 0,0023479743862571184
            Epoch 18122/20000, Loss: 0,0023478427670627993
            Epoch 18123/20000, Loss: 0,002347711161047637
            Epoch 18124/20000, Loss: 0,002347579568209779
            Epoch 18125/20000, Loss: 0,0023474479885473723
            Epoch 18126/20000, Loss: 0,002347316422058561
            Epoch 18127/20000, Loss: 0,0023471848687414937
            Epoch 18128/20000, Loss: 0,002347053328594313
            Epoch 18129/20000, Loss: 0,002346921801615171
            Epoch 18130/20000, Loss: 0,002346790287802213
            Epoch 18131/20000, Loss: 0,002346658787153585
            Epoch 18132/20000, Loss: 0,0023465272996674403
            Epoch 18133/20000, Loss: 0,0023463958253419235
            Epoch 18134/20000, Loss: 0,002346264364175185
            Epoch 18135/20000, Loss: 0,002346132916165373
            Epoch 18136/20000, Loss: 0,002346001481310638
            Epoch 18137/20000, Loss: 0,0023458700596091313
            Epoch 18138/20000, Loss: 0,002345738651059001
            Epoch 18139/20000, Loss: 0,0023456072556583977
            Epoch 18140/20000, Loss: 0,0023454758734054735
            Epoch 18141/20000, Loss: 0,002345344504298381
            Epoch 18142/20000, Loss: 0,00234521314833527
            Epoch 18143/20000, Loss: 0,002345081805514292
            Epoch 18144/20000, Loss: 0,0023449504758336014
            Epoch 18145/20000, Loss: 0,0023448191592913494
            Epoch 18146/20000, Loss: 0,0023446878558856907
            Epoch 18147/20000, Loss: 0,0023445565656147775
            Epoch 18148/20000, Loss: 0,002344425288476763
            Epoch 18149/20000, Loss: 0,0023442940244698027
            Epoch 18150/20000, Loss: 0,002344162773592051
            Epoch 18151/20000, Loss: 0,0023440315358416626
            Epoch 18152/20000, Loss: 0,002343900311216791
            Epoch 18153/20000, Loss: 0,002343769099715595
            Epoch 18154/20000, Loss: 0,002343637901336228
            Epoch 18155/20000, Loss: 0,002343506716076845
            Epoch 18156/20000, Loss: 0,002343375543935607
            Epoch 18157/20000, Loss: 0,002343244384910667
            Epoch 18158/20000, Loss: 0,002343113239000184
            Epoch 18159/20000, Loss: 0,0023429821062023156
            Epoch 18160/20000, Loss: 0,0023428509865152177
            Epoch 18161/20000, Loss: 0,002342719879937051
            Epoch 18162/20000, Loss: 0,0023425887864659736
            Epoch 18163/20000, Loss: 0,0023424577061001424
            Epoch 18164/20000, Loss: 0,002342326638837721
            Epoch 18165/20000, Loss: 0,0023421955846768664
            Epoch 18166/20000, Loss: 0,0023420645436157367
            Epoch 18167/20000, Loss: 0,0023419335156524947
            Epoch 18168/20000, Loss: 0,0023418025007853026
            Epoch 18169/20000, Loss: 0,0023416714990123193
            Epoch 18170/20000, Loss: 0,0023415405103317053
            Epoch 18171/20000, Loss: 0,002341409534741624
            Epoch 18172/20000, Loss: 0,0023412785722402374
            Epoch 18173/20000, Loss: 0,002341147622825707
            Epoch 18174/20000, Loss: 0,0023410166864961954
            Epoch 18175/20000, Loss: 0,002340885763249868
            Epoch 18176/20000, Loss: 0,0023407548530848853
            Epoch 18177/20000, Loss: 0,0023406239559994125
            Epoch 18178/20000, Loss: 0,0023404930719916157
            Epoch 18179/20000, Loss: 0,0023403622010596562
            Epoch 18180/20000, Loss: 0,0023402313432017005
            Epoch 18181/20000, Loss: 0,002340100498415913
            Epoch 18182/20000, Loss: 0,0023399696667004604
            Epoch 18183/20000, Loss: 0,0023398388480535062
            Epoch 18184/20000, Loss: 0,0023397080424732196
            Epoch 18185/20000, Loss: 0,002339577249957766
            Epoch 18186/20000, Loss: 0,0023394464705053116
            Epoch 18187/20000, Loss: 0,0023393157041140247
            Epoch 18188/20000, Loss: 0,002339184950782072
            Epoch 18189/20000, Loss: 0,002339054210507621
            Epoch 18190/20000, Loss: 0,0023389234832888422
            Epoch 18191/20000, Loss: 0,0023387927691239023
            Epoch 18192/20000, Loss: 0,0023386620680109715
            Epoch 18193/20000, Loss: 0,0023385313799482174
            Epoch 18194/20000, Loss: 0,0023384007049338114
            Epoch 18195/20000, Loss: 0,002338270042965924
            Epoch 18196/20000, Loss: 0,0023381393940427233
            Epoch 18197/20000, Loss: 0,0023380087581623818
            Epoch 18198/20000, Loss: 0,002337878135323069
            Epoch 18199/20000, Loss: 0,002337747525522956
            Epoch 18200/20000, Loss: 0,002337616928760217
            Epoch 18201/20000, Loss: 0,0023374863450330245
            Epoch 18202/20000, Loss: 0,002337355774339547
            Epoch 18203/20000, Loss: 0,002337225216677961
            Epoch 18204/20000, Loss: 0,0023370946720464372
            Epoch 18205/20000, Loss: 0,0023369641404431497
            Epoch 18206/20000, Loss: 0,002336833621866274
            Epoch 18207/20000, Loss: 0,002336703116313981
            Epoch 18208/20000, Loss: 0,0023365726237844476
            Epoch 18209/20000, Loss: 0,0023364421442758497
            Epoch 18210/20000, Loss: 0,0023363116777863594
            Epoch 18211/20000, Loss: 0,002336181224314153
            Epoch 18212/20000, Loss: 0,002336050783857409
            Epoch 18213/20000, Loss: 0,0023359203564143
            Epoch 18214/20000, Loss: 0,0023357899419830055
            Epoch 18215/20000, Loss: 0,0023356595405617008
            Epoch 18216/20000, Loss: 0,0023355291521485627
            Epoch 18217/20000, Loss: 0,0023353987767417692
            Epoch 18218/20000, Loss: 0,002335268414339499
            Epoch 18219/20000, Loss: 0,0023351380649399294
            Epoch 18220/20000, Loss: 0,0023350077285412404
            Epoch 18221/20000, Loss: 0,002334877405141611
            Epoch 18222/20000, Loss: 0,0023347470947392185
            Epoch 18223/20000, Loss: 0,002334616797332244
            Epoch 18224/20000, Loss: 0,0023344865129188664
            Epoch 18225/20000, Loss: 0,0023343562414972667
            Epoch 18226/20000, Loss: 0,002334225983065626
            Epoch 18227/20000, Loss: 0,002334095737622126
            Epoch 18228/20000, Loss: 0,002333965505164946
            Epoch 18229/20000, Loss: 0,0023338352856922687
            Epoch 18230/20000, Loss: 0,0023337050792022764
            Epoch 18231/20000, Loss: 0,002333574885693153
            Epoch 18232/20000, Loss: 0,0023334447051630764
            Epoch 18233/20000, Loss: 0,0023333145376102345
            Epoch 18234/20000, Loss: 0,002333184383032808
            Epoch 18235/20000, Loss: 0,002333054241428982
            Epoch 18236/20000, Loss: 0,002332924112796942
            Epoch 18237/20000, Loss: 0,0023327939971348687
            Epoch 18238/20000, Loss: 0,0023326638944409497
            Epoch 18239/20000, Loss: 0,0023325338047133696
            Epoch 18240/20000, Loss: 0,0023324037279503144
            Epoch 18241/20000, Loss: 0,0023322736641499687
            Epoch 18242/20000, Loss: 0,002332143613310519
            Epoch 18243/20000, Loss: 0,0023320135754301514
            Epoch 18244/20000, Loss: 0,0023318835505070534
            Epoch 18245/20000, Loss: 0,002331753538539413
            Epoch 18246/20000, Loss: 0,0023316235395254158
            Epoch 18247/20000, Loss: 0,002331493553463253
            Epoch 18248/20000, Loss: 0,0023313635803511082
            Epoch 18249/20000, Loss: 0,0023312336201871723
            Epoch 18250/20000, Loss: 0,0023311036729696355
            Epoch 18251/20000, Loss: 0,002330973738696685
            Epoch 18252/20000, Loss: 0,0023308438173665126
            Epoch 18253/20000, Loss: 0,002330713908977305
            Epoch 18254/20000, Loss: 0,002330584013527255
            Epoch 18255/20000, Loss: 0,0023304541310145534
            Epoch 18256/20000, Loss: 0,002330324261437389
            Epoch 18257/20000, Loss: 0,002330194404793955
            Epoch 18258/20000, Loss: 0,0023300645610824415
            Epoch 18259/20000, Loss: 0,0023299347303010415
            Epoch 18260/20000, Loss: 0,0023298049124479497
            Epoch 18261/20000, Loss: 0,002329675107521355
            Epoch 18262/20000, Loss: 0,0023295453155194506
            Epoch 18263/20000, Loss: 0,0023294155364404325
            Epoch 18264/20000, Loss: 0,002329285770282492
            Epoch 18265/20000, Loss: 0,002329156017043825
            Epoch 18266/20000, Loss: 0,0023290262767226245
            Epoch 18267/20000, Loss: 0,0023288965493170857
            Epoch 18268/20000, Loss: 0,0023287668348254027
            Epoch 18269/20000, Loss: 0,002328637133245773
            Epoch 18270/20000, Loss: 0,002328507444576391
            Epoch 18271/20000, Loss: 0,0023283777688154527
            Epoch 18272/20000, Loss: 0,0023282481059611554
            Epoch 18273/20000, Loss: 0,002328118456011695
            Epoch 18274/20000, Loss: 0,0023279888189652693
            Epoch 18275/20000, Loss: 0,002327859194820075
            Epoch 18276/20000, Loss: 0,0023277295835743097
            Epoch 18277/20000, Loss: 0,0023275999852261733
            Epoch 18278/20000, Loss: 0,0023274703997738628
            Epoch 18279/20000, Loss: 0,002327340827215577
            Epoch 18280/20000, Loss: 0,0023272112675495156
            Epoch 18281/20000, Loss: 0,002327081720773878
            Epoch 18282/20000, Loss: 0,0023269521868868642
            Epoch 18283/20000, Loss: 0,002326822665886675
            Epoch 18284/20000, Loss: 0,0023266931577715084
            Epoch 18285/20000, Loss: 0,002326563662539567
            Epoch 18286/20000, Loss: 0,0023264341801890534
            Epoch 18287/20000, Loss: 0,002326304710718167
            Epoch 18288/20000, Loss: 0,00232617525412511
            Epoch 18289/20000, Loss: 0,0023260458104080862
            Epoch 18290/20000, Loss: 0,002325916379565297
            Epoch 18291/20000, Loss: 0,002325786961594946
            Epoch 18292/20000, Loss: 0,0023256575564952336
            Epoch 18293/20000, Loss: 0,0023255281642643685
            Epoch 18294/20000, Loss: 0,0023253987849005497
            Epoch 18295/20000, Loss: 0,0023252694184019854
            Epoch 18296/20000, Loss: 0,0023251400647668783
            Epoch 18297/20000, Loss: 0,0023250107239934322
            Epoch 18298/20000, Loss: 0,002324881396079854
            Epoch 18299/20000, Loss: 0,0023247520810243502
            Epoch 18300/20000, Loss: 0,002324622778825124
            Epoch 18301/20000, Loss: 0,0023244934894803854
            Epoch 18302/20000, Loss: 0,002324364212988338
            Epoch 18303/20000, Loss: 0,0023242349493471895
            Epoch 18304/20000, Loss: 0,00232410569855515
            Epoch 18305/20000, Loss: 0,002323976460610422
            Epoch 18306/20000, Loss: 0,0023238472355112177
            Epoch 18307/20000, Loss: 0,0023237180232557426
            Epoch 18308/20000, Loss: 0,0023235888238422094
            Epoch 18309/20000, Loss: 0,0023234596372688245
            Epoch 18310/20000, Loss: 0,002323330463533797
            Epoch 18311/20000, Loss: 0,0023232013026353356
            Epoch 18312/20000, Loss: 0,0023230721545716535
            Epoch 18313/20000, Loss: 0,0023229430193409594
            Epoch 18314/20000, Loss: 0,002322813896941465
            Epoch 18315/20000, Loss: 0,0023226847873713805
            Epoch 18316/20000, Loss: 0,0023225556906289165
            Epoch 18317/20000, Loss: 0,002322426606712286
            Epoch 18318/20000, Loss: 0,0023222975356197
            Epoch 18319/20000, Loss: 0,0023221684773493743
            Epoch 18320/20000, Loss: 0,0023220394318995167
            Epoch 18321/20000, Loss: 0,002321910399268345
            Epoch 18322/20000, Loss: 0,0023217813794540704
            Epoch 18323/20000, Loss: 0,0023216523724549063
            Epoch 18324/20000, Loss: 0,002321523378269066
            Epoch 18325/20000, Loss: 0,0023213943968947675
            Epoch 18326/20000, Loss: 0,0023212654283302214
            Epoch 18327/20000, Loss: 0,002321136472573647
            Epoch 18328/20000, Loss: 0,0023210075296232566
            Epoch 18329/20000, Loss: 0,0023208785994772684
            Epoch 18330/20000, Loss: 0,002320749682133898
            Epoch 18331/20000, Loss: 0,002320620777591361
            Epoch 18332/20000, Loss: 0,002320491885847873
            Epoch 18333/20000, Loss: 0,002320363006901655
            Epoch 18334/20000, Loss: 0,0023202341407509226
            Epoch 18335/20000, Loss: 0,002320105287393892
            Epoch 18336/20000, Loss: 0,0023199764468287837
            Epoch 18337/20000, Loss: 0,0023198476190538155
            Epoch 18338/20000, Loss: 0,002319718804067206
            Epoch 18339/20000, Loss: 0,002319590001867176
            Epoch 18340/20000, Loss: 0,0023194612124519455
            Epoch 18341/20000, Loss: 0,0023193324358197296
            Epoch 18342/20000, Loss: 0,002319203671968753
            Epoch 18343/20000, Loss: 0,0023190749208972356
            Epoch 18344/20000, Loss: 0,002318946182603398
            Epoch 18345/20000, Loss: 0,0023188174570854606
            Epoch 18346/20000, Loss: 0,002318688744341646
            Epoch 18347/20000, Loss: 0,0023185600443701767
            Epoch 18348/20000, Loss: 0,0023184313571692743
            Epoch 18349/20000, Loss: 0,00231830268273716
            Epoch 18350/20000, Loss: 0,0023181740210720596
            Epoch 18351/20000, Loss: 0,0023180453721721966
            Epoch 18352/20000, Loss: 0,0023179167360357906
            Epoch 18353/20000, Loss: 0,002317788112661067
            Epoch 18354/20000, Loss: 0,002317659502046254
            Epoch 18355/20000, Loss: 0,002317530904189573
            Epoch 18356/20000, Loss: 0,0023174023190892486
            Epoch 18357/20000, Loss: 0,0023172737467435076
            Epoch 18358/20000, Loss: 0,002317145187150575
            Epoch 18359/20000, Loss: 0,002317016640308677
            Epoch 18360/20000, Loss: 0,0023168881062160408
            Epoch 18361/20000, Loss: 0,0023167595848708916
            Epoch 18362/20000, Loss: 0,0023166310762714566
            Epoch 18363/20000, Loss: 0,0023165025804159642
            Epoch 18364/20000, Loss: 0,0023163740973026403
            Epoch 18365/20000, Loss: 0,002316245626929716
            Epoch 18366/20000, Loss: 0,0023161171692954183
            Epoch 18367/20000, Loss: 0,002315988724397974
            Epoch 18368/20000, Loss: 0,0023158602922356145
            Epoch 18369/20000, Loss: 0,0023157318728065685
            Epoch 18370/20000, Loss: 0,002315603466109066
            Epoch 18371/20000, Loss: 0,0023154750721413367
            Epoch 18372/20000, Loss: 0,002315346690901611
            Epoch 18373/20000, Loss: 0,0023152183223881196
            Epoch 18374/20000, Loss: 0,0023150899665990944
            Epoch 18375/20000, Loss: 0,002314961623532765
            Epoch 18376/20000, Loss: 0,0023148332931873664
            Epoch 18377/20000, Loss: 0,0023147049755611266
            Epoch 18378/20000, Loss: 0,002314576670652281
            Epoch 18379/20000, Loss: 0,0023144483784590616
            Epoch 18380/20000, Loss: 0,0023143200989797015
            Epoch 18381/20000, Loss: 0,0023141918322124354
            Epoch 18382/20000, Loss: 0,0023140635781554943
            Epoch 18383/20000, Loss: 0,002313935336807114
            Epoch 18384/20000, Loss: 0,0023138071081655292
            Epoch 18385/20000, Loss: 0,002313678892228975
            Epoch 18386/20000, Loss: 0,002313550688995685
            Epoch 18387/20000, Loss: 0,0023134224984638955
            Epoch 18388/20000, Loss: 0,0023132943206318436
            Epoch 18389/20000, Loss: 0,0023131661554977633
            Epoch 18390/20000, Loss: 0,0023130380030598925
            Epoch 18391/20000, Loss: 0,0023129098633164675
            Epoch 18392/20000, Loss: 0,002312781736265726
            Epoch 18393/20000, Loss: 0,002312653621905905
            Epoch 18394/20000, Loss: 0,0023125255202352413
            Epoch 18395/20000, Loss: 0,0023123974312519763
            Epoch 18396/20000, Loss: 0,002312269354954346
            Epoch 18397/20000, Loss: 0,002312141291340588
            Epoch 18398/20000, Loss: 0,0023120132404089453
            Epoch 18399/20000, Loss: 0,002311885202157655
            Epoch 18400/20000, Loss: 0,0023117571765849556
            Epoch 18401/20000, Loss: 0,0023116291636890917
            Epoch 18402/20000, Loss: 0,0023115011634682993
            Epoch 18403/20000, Loss: 0,0023113731759208224
            Epoch 18404/20000, Loss: 0,0023112452010449
            Epoch 18405/20000, Loss: 0,002311117238838775
            Epoch 18406/20000, Loss: 0,0023109892893006883
            Epoch 18407/20000, Loss: 0,002310861352428883
            Epoch 18408/20000, Loss: 0,0023107334282216024
            Epoch 18409/20000, Loss: 0,002310605516677088
            Epoch 18410/20000, Loss: 0,0023104776177935832
            Epoch 18411/20000, Loss: 0,0023103497315693318
            Epoch 18412/20000, Loss: 0,002310221858002579
            Epoch 18413/20000, Loss: 0,0023100939970915665
            Epoch 18414/20000, Loss: 0,0023099661488345394
            Epoch 18415/20000, Loss: 0,0023098383132297436
            Epoch 18416/20000, Loss: 0,002309710490275425
            Epoch 18417/20000, Loss: 0,0023095826799698293
            Epoch 18418/20000, Loss: 0,0023094548823112005
            Epoch 18419/20000, Loss: 0,002309327097297785
            Epoch 18420/20000, Loss: 0,00230919932492783
            Epoch 18421/20000, Loss: 0,002309071565199584
            Epoch 18422/20000, Loss: 0,0023089438181112913
            Epoch 18423/20000, Loss: 0,002308816083661201
            Epoch 18424/20000, Loss: 0,002308688361847563
            Epoch 18425/20000, Loss: 0,002308560652668623
            Epoch 18426/20000, Loss: 0,0023084329561226294
            Epoch 18427/20000, Loss: 0,0023083052722078327
            Epoch 18428/20000, Loss: 0,0023081776009224826
            Epoch 18429/20000, Loss: 0,0023080499422648247
            Epoch 18430/20000, Loss: 0,002307922296233114
            Epoch 18431/20000, Loss: 0,0023077946628255993
            Epoch 18432/20000, Loss: 0,0023076670420405297
            Epoch 18433/20000, Loss: 0,0023075394338761567
            Epoch 18434/20000, Loss: 0,0023074118383307318
            Epoch 18435/20000, Loss: 0,002307284255402508
            Epoch 18436/20000, Loss: 0,0023071566850897353
            Epoch 18437/20000, Loss: 0,0023070291273906657
            Epoch 18438/20000, Loss: 0,002306901582303555
            Epoch 18439/20000, Loss: 0,0023067740498266534
            Epoch 18440/20000, Loss: 0,002306646529958214
            Epoch 18441/20000, Loss: 0,0023065190226964913
            Epoch 18442/20000, Loss: 0,0023063915280397405
            Epoch 18443/20000, Loss: 0,002306264045986213
            Epoch 18444/20000, Loss: 0,0023061365765341653
            Epoch 18445/20000, Loss: 0,002306009119681852
            Epoch 18446/20000, Loss: 0,00230588167542753
            Epoch 18447/20000, Loss: 0,002305754243769452
            Epoch 18448/20000, Loss: 0,0023056268247058777
            Epoch 18449/20000, Loss: 0,0023054994182350606
            Epoch 18450/20000, Loss: 0,0023053720243552565
            Epoch 18451/20000, Loss: 0,0023052446430647253
            Epoch 18452/20000, Loss: 0,002305117274361721
            Epoch 18453/20000, Loss: 0,002304989918244505
            Epoch 18454/20000, Loss: 0,0023048625747113314
            Epoch 18455/20000, Loss: 0,0023047352437604645
            Epoch 18456/20000, Loss: 0,002304607925390155
            Epoch 18457/20000, Loss: 0,0023044806195986678
            Epoch 18458/20000, Loss: 0,0023043533263842585
            Epoch 18459/20000, Loss: 0,0023042260457451914
            Epoch 18460/20000, Loss: 0,0023040987776797224
            Epoch 18461/20000, Loss: 0,0023039715221861118
            Epoch 18462/20000, Loss: 0,002303844279262624
            Epoch 18463/20000, Loss: 0,0023037170489075163
            Epoch 18464/20000, Loss: 0,0023035898311190507
            Epoch 18465/20000, Loss: 0,0023034626258954887
            Epoch 18466/20000, Loss: 0,002303335433235096
            Epoch 18467/20000, Loss: 0,0023032082531361303
            Epoch 18468/20000, Loss: 0,0023030810855968562
            Epoch 18469/20000, Loss: 0,002302953930615536
            Epoch 18470/20000, Loss: 0,002302826788190434
            Epoch 18471/20000, Loss: 0,002302699658319811
            Epoch 18472/20000, Loss: 0,002302572541001937
            Epoch 18473/20000, Loss: 0,0023024454362350717
            Epoch 18474/20000, Loss: 0,002302318344017479
            Epoch 18475/20000, Loss: 0,002302191264347427
            Epoch 18476/20000, Loss: 0,002302064197223179
            Epoch 18477/20000, Loss: 0,002301937142643003
            Epoch 18478/20000, Loss: 0,002301810100605162
            Epoch 18479/20000, Loss: 0,002301683071107923
            Epoch 18480/20000, Loss: 0,0023015560541495544
            Epoch 18481/20000, Loss: 0,002301429049728322
            Epoch 18482/20000, Loss: 0,002301302057842493
            Epoch 18483/20000, Loss: 0,0023011750784903357
            Epoch 18484/20000, Loss: 0,0023010481116701167
            Epoch 18485/20000, Loss: 0,002300921157380106
            Epoch 18486/20000, Loss: 0,0023007942156185726
            Epoch 18487/20000, Loss: 0,002300667286383783
            Epoch 18488/20000, Loss: 0,002300540369674009
            Epoch 18489/20000, Loss: 0,0023004134654875195
            Epoch 18490/20000, Loss: 0,0023002865738225827
            Epoch 18491/20000, Loss: 0,0023001596946774726
            Epoch 18492/20000, Loss: 0,002300032828050456
            Epoch 18493/20000, Loss: 0,002299905973939807
            Epoch 18494/20000, Loss: 0,0022997791323437944
            Epoch 18495/20000, Loss: 0,0022996523032606923
            Epoch 18496/20000, Loss: 0,0022995254866887706
            Epoch 18497/20000, Loss: 0,002299398682626303
            Epoch 18498/20000, Loss: 0,002299271891071562
            Epoch 18499/20000, Loss: 0,00229914511202282
            Epoch 18500/20000, Loss: 0,0022990183454783494
            Epoch 18501/20000, Loss: 0,002298891591436426
            Epoch 18502/20000, Loss: 0,0022987648498953217
            Epoch 18503/20000, Loss: 0,0022986381208533126
            Epoch 18504/20000, Loss: 0,002298511404308674
            Epoch 18505/20000, Loss: 0,002298384700259677
            Epoch 18506/20000, Loss: 0,0022982580087046013
            Epoch 18507/20000, Loss: 0,00229813132964172
            Epoch 18508/20000, Loss: 0,0022980046630693097
            Epoch 18509/20000, Loss: 0,002297878008985647
            Epoch 18510/20000, Loss: 0,0022977513673890066
            Epoch 18511/20000, Loss: 0,0022976247382776693
            Epoch 18512/20000, Loss: 0,002297498121649909
            Epoch 18513/20000, Loss: 0,0022973715175040052
            Epoch 18514/20000, Loss: 0,0022972449258382363
            Epoch 18515/20000, Loss: 0,0022971183466508785
            Epoch 18516/20000, Loss: 0,0022969917799402105
            Epoch 18517/20000, Loss: 0,0022968652257045145
            Epoch 18518/20000, Loss: 0,0022967386839420653
            Epoch 18519/20000, Loss: 0,002296612154651147
            Epoch 18520/20000, Loss: 0,0022964856378300358
            Epoch 18521/20000, Loss: 0,002296359133477013
            Epoch 18522/20000, Loss: 0,0022962326415903603
            Epoch 18523/20000, Loss: 0,002296106162168357
            Epoch 18524/20000, Loss: 0,0022959796952092878
            Epoch 18525/20000, Loss: 0,0022958532407114304
            Epoch 18526/20000, Loss: 0,0022957267986730683
            Epoch 18527/20000, Loss: 0,0022956003690924845
            Epoch 18528/20000, Loss: 0,0022954739519679603
            Epoch 18529/20000, Loss: 0,0022953475472977792
            Epoch 18530/20000, Loss: 0,0022952211550802235
            Epoch 18531/20000, Loss: 0,0022950947753135795
            Epoch 18532/20000, Loss: 0,0022949684079961287
            Epoch 18533/20000, Loss: 0,0022948420531261554
            Epoch 18534/20000, Loss: 0,0022947157107019453
            Epoch 18535/20000, Loss: 0,002294589380721783
            Epoch 18536/20000, Loss: 0,002294463063183953
            Epoch 18537/20000, Loss: 0,002294336758086743
            Epoch 18538/20000, Loss: 0,002294210465428436
            Epoch 18539/20000, Loss: 0,0022940841852073187
            Epoch 18540/20000, Loss: 0,0022939579174216804
            Epoch 18541/20000, Loss: 0,0022938316620698044
            Epoch 18542/20000, Loss: 0,0022937054191499804
            Epoch 18543/20000, Loss: 0,0022935791886604965
            Epoch 18544/20000, Loss: 0,0022934529705996385
            Epoch 18545/20000, Loss: 0,0022933267649656946
            Epoch 18546/20000, Loss: 0,0022932005717569547
            Epoch 18547/20000, Loss: 0,002293074390971708
            Epoch 18548/20000, Loss: 0,002292948222608242
            Epoch 18549/20000, Loss: 0,0022928220666648485
            Epoch 18550/20000, Loss: 0,0022926959231398146
            Epoch 18551/20000, Loss: 0,0022925697920314317
            Epoch 18552/20000, Loss: 0,002292443673337992
            Epoch 18553/20000, Loss: 0,002292317567057784
            Epoch 18554/20000, Loss: 0,0022921914731890984
            Epoch 18555/20000, Loss: 0,00229206539173023
            Epoch 18556/20000, Loss: 0,002291939322679468
            Epoch 18557/20000, Loss: 0,0022918132660351047
            Epoch 18558/20000, Loss: 0,0022916872217954346
            Epoch 18559/20000, Loss: 0,002291561189958748
            Epoch 18560/20000, Loss: 0,00229143517052334
            Epoch 18561/20000, Loss: 0,002291309163487503
            Epoch 18562/20000, Loss: 0,002291183168849531
            Epoch 18563/20000, Loss: 0,0022910571866077175
            Epoch 18564/20000, Loss: 0,0022909312167603583
            Epoch 18565/20000, Loss: 0,0022908052593057482
            Epoch 18566/20000, Loss: 0,002290679314242182
            Epoch 18567/20000, Loss: 0,0022905533815679546
            Epoch 18568/20000, Loss: 0,002290427461281362
            Epoch 18569/20000, Loss: 0,0022903015533807004
            Epoch 18570/20000, Loss: 0,002290175657864266
            Epoch 18571/20000, Loss: 0,0022900497747303573
            Epoch 18572/20000, Loss: 0,002289923903977269
            Epoch 18573/20000, Loss: 0,002289798045603299
            Epoch 18574/20000, Loss: 0,0022896721996067473
            Epoch 18575/20000, Loss: 0,0022895463659859086
            Epoch 18576/20000, Loss: 0,002289420544739084
            Epoch 18577/20000, Loss: 0,002289294735864571
            Epoch 18578/20000, Loss: 0,0022891689393606703
            Epoch 18579/20000, Loss: 0,002289043155225678
            Epoch 18580/20000, Loss: 0,002288917383457897
            Epoch 18581/20000, Loss: 0,002288791624055626
            Epoch 18582/20000, Loss: 0,0022886658770171664
            Epoch 18583/20000, Loss: 0,002288540142340816
            Epoch 18584/20000, Loss: 0,0022884144200248794
            Epoch 18585/20000, Loss: 0,002288288710067656
            Epoch 18586/20000, Loss: 0,0022881630124674487
            Epoch 18587/20000, Loss: 0,0022880373272225587
            Epoch 18588/20000, Loss: 0,002287911654331288
            Epoch 18589/20000, Loss: 0,002287785993791941
            Epoch 18590/20000, Loss: 0,0022876603456028185
            Epoch 18591/20000, Loss: 0,0022875347097622263
            Epoch 18592/20000, Loss: 0,0022874090862684635
            Epoch 18593/20000, Loss: 0,0022872834751198412
            Epoch 18594/20000, Loss: 0,0022871578763146577
            Epoch 18595/20000, Loss: 0,0022870322898512203
            Epoch 18596/20000, Loss: 0,0022869067157278325
            Epoch 18597/20000, Loss: 0,0022867811539428037
            Epoch 18598/20000, Loss: 0,002286655604494433
            Epoch 18599/20000, Loss: 0,0022865300673810315
            Epoch 18600/20000, Loss: 0,0022864045426009036
            Epoch 18601/20000, Loss: 0,002286279030152355
            Epoch 18602/20000, Loss: 0,002286153530033694
            Epoch 18603/20000, Loss: 0,002286028042243229
            Epoch 18604/20000, Loss: 0,0022859025667792644
            Epoch 18605/20000, Loss: 0,0022857771036401114
            Epoch 18606/20000, Loss: 0,002285651652824075
            Epoch 18607/20000, Loss: 0,0022855262143294678
            Epoch 18608/20000, Loss: 0,0022854007881545958
            Epoch 18609/20000, Loss: 0,002285275374297768
            Epoch 18610/20000, Loss: 0,002285149972757295
            Epoch 18611/20000, Loss: 0,002285024583531488
            Epoch 18612/20000, Loss: 0,0022848992066186536
            Epoch 18613/20000, Loss: 0,002284773842017106
            Epoch 18614/20000, Loss: 0,002284648489725155
            Epoch 18615/20000, Loss: 0,00228452314974111
            Epoch 18616/20000, Loss: 0,002284397822063285
            Epoch 18617/20000, Loss: 0,00228427250668999
            Epoch 18618/20000, Loss: 0,002284147203619539
            Epoch 18619/20000, Loss: 0,002284021912850243
            Epoch 18620/20000, Loss: 0,0022838966343804146
            Epoch 18621/20000, Loss: 0,0022837713682083687
            Epoch 18622/20000, Loss: 0,0022836461143324162
            Epoch 18623/20000, Loss: 0,002283520872750873
            Epoch 18624/20000, Loss: 0,0022833956434620524
            Epoch 18625/20000, Loss: 0,0022832704264642697
            Epoch 18626/20000, Loss: 0,002283145221755839
            Epoch 18627/20000, Loss: 0,0022830200293350754
            Epoch 18628/20000, Loss: 0,002282894849200294
            Epoch 18629/20000, Loss: 0,0022827696813498117
            Epoch 18630/20000, Loss: 0,002282644525781944
            Epoch 18631/20000, Loss: 0,002282519382495007
            Epoch 18632/20000, Loss: 0,0022823942514873185
            Epoch 18633/20000, Loss: 0,002282269132757193
            Epoch 18634/20000, Loss: 0,002282144026302949
            Epoch 18635/20000, Loss: 0,002282018932122906
            Epoch 18636/20000, Loss: 0,00228189385021538
            Epoch 18637/20000, Loss: 0,0022817687805786907
            Epoch 18638/20000, Loss: 0,002281643723211157
            Epoch 18639/20000, Loss: 0,002281518678111096
            Epoch 18640/20000, Loss: 0,0022813936452768285
            Epoch 18641/20000, Loss: 0,002281268624706674
            Epoch 18642/20000, Loss: 0,0022811436163989516
            Epoch 18643/20000, Loss: 0,002281018620351984
            Epoch 18644/20000, Loss: 0,0022808936365640896
            Epoch 18645/20000, Loss: 0,0022807686650335893
            Epoch 18646/20000, Loss: 0,002280643705758806
            Epoch 18647/20000, Loss: 0,00228051875873806
            Epoch 18648/20000, Loss: 0,0022803938239696732
            Epoch 18649/20000, Loss: 0,0022802689014519684
            Epoch 18650/20000, Loss: 0,0022801439911832666
            Epoch 18651/20000, Loss: 0,0022800190931618947
            Epoch 18652/20000, Loss: 0,0022798942073861722
            Epoch 18653/20000, Loss: 0,0022797693338544246
            Epoch 18654/20000, Loss: 0,002279644472564974
            Epoch 18655/20000, Loss: 0,0022795196235161474
            Epoch 18656/20000, Loss: 0,002279394786706266
            Epoch 18657/20000, Loss: 0,0022792699621336557
            Epoch 18658/20000, Loss: 0,0022791451497966428
            Epoch 18659/20000, Loss: 0,002279020349693553
            Epoch 18660/20000, Loss: 0,002278895561822711
            Epoch 18661/20000, Loss: 0,0022787707861824423
            Epoch 18662/20000, Loss: 0,0022786460227710763
            Epoch 18663/20000, Loss: 0,002278521271586937
            Epoch 18664/20000, Loss: 0,0022783965326283514
            Epoch 18665/20000, Loss: 0,0022782718058936492
            Epoch 18666/20000, Loss: 0,0022781470913811564
            Epoch 18667/20000, Loss: 0,0022780223890892016
            Epoch 18668/20000, Loss: 0,0022778976990161137
            Epoch 18669/20000, Loss: 0,0022777730211602206
            Epoch 18670/20000, Loss: 0,002277648355519853
            Epoch 18671/20000, Loss: 0,0022775237020933366
            Epoch 18672/20000, Loss: 0,0022773990608790057
            Epoch 18673/20000, Loss: 0,002277274431875187
            Epoch 18674/20000, Loss: 0,0022771498150802134
            Epoch 18675/20000, Loss: 0,002277025210492413
            Epoch 18676/20000, Loss: 0,0022769006181101166
            Epoch 18677/20000, Loss: 0,0022767760379316603
            Epoch 18678/20000, Loss: 0,00227665146995537
            Epoch 18679/20000, Loss: 0,0022765269141795806
            Epoch 18680/20000, Loss: 0,002276402370602625
            Epoch 18681/20000, Loss: 0,0022762778392228346
            Epoch 18682/20000, Loss: 0,0022761533200385395
            Epoch 18683/20000, Loss: 0,0022760288130480796
            Epoch 18684/20000, Loss: 0,0022759043182497838
            Epoch 18685/20000, Loss: 0,0022757798356419856
            Epoch 18686/20000, Loss: 0,0022756553652230225
            Epoch 18687/20000, Loss: 0,0022755309069912256
            Epoch 18688/20000, Loss: 0,0022754064609449326
            Epoch 18689/20000, Loss: 0,002275282027082477
            Epoch 18690/20000, Loss: 0,002275157605402195
            Epoch 18691/20000, Loss: 0,0022750331959024224
            Epoch 18692/20000, Loss: 0,0022749087985814947
            Epoch 18693/20000, Loss: 0,002274784413437748
            Epoch 18694/20000, Loss: 0,0022746600404695222
            Epoch 18695/20000, Loss: 0,0022745356796751515
            Epoch 18696/20000, Loss: 0,002274411331052973
            Epoch 18697/20000, Loss: 0,002274286994601326
            Epoch 18698/20000, Loss: 0,0022741626703185495
            Epoch 18699/20000, Loss: 0,0022740383582029794
            Epoch 18700/20000, Loss: 0,002273914058252957
            Epoch 18701/20000, Loss: 0,0022737897704668184
            Epoch 18702/20000, Loss: 0,002273665494842906
            Epoch 18703/20000, Loss: 0,002273541231379557
            Epoch 18704/20000, Loss: 0,0022734169800751134
            Epoch 18705/20000, Loss: 0,002273292740927914
            Epoch 18706/20000, Loss: 0,0022731685139363
            Epoch 18707/20000, Loss: 0,0022730442990986127
            Epoch 18708/20000, Loss: 0,002272920096413194
            Epoch 18709/20000, Loss: 0,002272795905878385
            Epoch 18710/20000, Loss: 0,0022726717274925267
            Epoch 18711/20000, Loss: 0,0022725475612539623
            Epoch 18712/20000, Loss: 0,002272423407161034
            Epoch 18713/20000, Loss: 0,002272299265212087
            Epoch 18714/20000, Loss: 0,0022721751354054603
            Epoch 18715/20000, Loss: 0,0022720510177395006
            Epoch 18716/20000, Loss: 0,00227192691221255
            Epoch 18717/20000, Loss: 0,0022718028188229546
            Epoch 18718/20000, Loss: 0,0022716787375690562
            Epoch 18719/20000, Loss: 0,0022715546684492034
            Epoch 18720/20000, Loss: 0,002271430611461737
            Epoch 18721/20000, Loss: 0,002271306566605008
            Epoch 18722/20000, Loss: 0,0022711825338773564
            Epoch 18723/20000, Loss: 0,0022710585132771316
            Epoch 18724/20000, Loss: 0,0022709345048026806
            Epoch 18725/20000, Loss: 0,0022708105084523478
            Epoch 18726/20000, Loss: 0,0022706865242244816
            Epoch 18727/20000, Loss: 0,0022705625521174297
            Epoch 18728/20000, Loss: 0,0022704385921295386
            Epoch 18729/20000, Loss: 0,002270314644259158
            Epoch 18730/20000, Loss: 0,002270190708504636
            Epoch 18731/20000, Loss: 0,0022700667848643188
            Epoch 18732/20000, Loss: 0,002269942873336559
            Epoch 18733/20000, Loss: 0,0022698189739197017
            Epoch 18734/20000, Loss: 0,0022696950866121007
            Epoch 18735/20000, Loss: 0,002269571211412106
            Epoch 18736/20000, Loss: 0,0022694473483180645
            Epoch 18737/20000, Loss: 0,0022693234973283276
            Epoch 18738/20000, Loss: 0,0022691996584412485
            Epoch 18739/20000, Loss: 0,0022690758316551776
            Epoch 18740/20000, Loss: 0,002268952016968465
            Epoch 18741/20000, Loss: 0,0022688282143794648
            Epoch 18742/20000, Loss: 0,0022687044238865273
            Epoch 18743/20000, Loss: 0,0022685806454880056
            Epoch 18744/20000, Loss: 0,0022684568791822507
            Epoch 18745/20000, Loss: 0,0022683331249676213
            Epoch 18746/20000, Loss: 0,002268209382842465
            Epoch 18747/20000, Loss: 0,002268085652805139
            Epoch 18748/20000, Loss: 0,002267961934853996
            Epoch 18749/20000, Loss: 0,0022678382289873897
            Epoch 18750/20000, Loss: 0,002267714535203678
            Epoch 18751/20000, Loss: 0,0022675908535012114
            Epoch 18752/20000, Loss: 0,0022674671838783496
            Epoch 18753/20000, Loss: 0,0022673435263334475
            Epoch 18754/20000, Loss: 0,002267219880864857
            Epoch 18755/20000, Loss: 0,00226709624747094
            Epoch 18756/20000, Loss: 0,0022669726261500493
            Epoch 18757/20000, Loss: 0,002266849016900545
            Epoch 18758/20000, Loss: 0,002266725419720781
            Epoch 18759/20000, Loss: 0,0022666018346091175
            Epoch 18760/20000, Loss: 0,0022664782615639126
            Epoch 18761/20000, Loss: 0,002266354700583522
            Epoch 18762/20000, Loss: 0,0022662311516663063
            Epoch 18763/20000, Loss: 0,002266107614810625
            Epoch 18764/20000, Loss: 0,002265984090014835
            Epoch 18765/20000, Loss: 0,002265860577277297
            Epoch 18766/20000, Loss: 0,0022657370765963728
            Epoch 18767/20000, Loss: 0,002265613587970419
            Epoch 18768/20000, Loss: 0,0022654901113977983
            Epoch 18769/20000, Loss: 0,002265366646876871
            Epoch 18770/20000, Loss: 0,0022652431944059992
            Epoch 18771/20000, Loss: 0,0022651197539835426
            Epoch 18772/20000, Loss: 0,002264996325607864
            Epoch 18773/20000, Loss: 0,0022648729092773247
            Epoch 18774/20000, Loss: 0,002264749504990288
            Epoch 18775/20000, Loss: 0,0022646261127451154
            Epoch 18776/20000, Loss: 0,0022645027325401725
            Epoch 18777/20000, Loss: 0,00226437936437382
            Epoch 18778/20000, Loss: 0,0022642560082444226
            Epoch 18779/20000, Loss: 0,0022641326641503435
            Epoch 18780/20000, Loss: 0,002264009332089947
            Epoch 18781/20000, Loss: 0,0022638860120616005
            Epoch 18782/20000, Loss: 0,0022637627040636653
            Epoch 18783/20000, Loss: 0,0022636394080945096
            Epoch 18784/20000, Loss: 0,0022635161241524966
            Epoch 18785/20000, Loss: 0,002263392852235993
            Epoch 18786/20000, Loss: 0,002263269592343365
            Epoch 18787/20000, Loss: 0,0022631463444729794
            Epoch 18788/20000, Loss: 0,0022630231086232027
            Epoch 18789/20000, Loss: 0,002262899884792403
            Epoch 18790/20000, Loss: 0,0022627766729789458
            Epoch 18791/20000, Loss: 0,0022626534731812003
            Epoch 18792/20000, Loss: 0,002262530285397534
            Epoch 18793/20000, Loss: 0,002262407109626316
            Epoch 18794/20000, Loss: 0,002262283945865915
            Epoch 18795/20000, Loss: 0,0022621607941147007
            Epoch 18796/20000, Loss: 0,002262037654371039
            Epoch 18797/20000, Loss: 0,0022619145266333037
            Epoch 18798/20000, Loss: 0,0022617914108998636
            Epoch 18799/20000, Loss: 0,0022616683071690867
            Epoch 18800/20000, Loss: 0,0022615452154393463
            Epoch 18801/20000, Loss: 0,0022614221357090125
            Epoch 18802/20000, Loss: 0,0022612990679764574
            Epoch 18803/20000, Loss: 0,0022611760122400516
            Epoch 18804/20000, Loss: 0,0022610529684981657
            Epoch 18805/20000, Loss: 0,0022609299367491757
            Epoch 18806/20000, Loss: 0,0022608069169914495
            Epoch 18807/20000, Loss: 0,0022606839092233636
            Epoch 18808/20000, Loss: 0,002260560913443289
            Epoch 18809/20000, Loss: 0,0022604379296495996
            Epoch 18810/20000, Loss: 0,0022603149578406707
            Epoch 18811/20000, Loss: 0,0022601919980148747
            Epoch 18812/20000, Loss: 0,0022600690501705873
            Epoch 18813/20000, Loss: 0,0022599461143061805
            Epoch 18814/20000, Loss: 0,0022598231904200324
            Epoch 18815/20000, Loss: 0,0022597002785105175
            Epoch 18816/20000, Loss: 0,00225957737857601
            Epoch 18817/20000, Loss: 0,0022594544906148887
            Epoch 18818/20000, Loss: 0,002259331614625527
            Epoch 18819/20000, Loss: 0,0022592087506063028
            Epoch 18820/20000, Loss: 0,0022590858985555937
            Epoch 18821/20000, Loss: 0,002258963058471775
            Epoch 18822/20000, Loss: 0,0022588402303532285
            Epoch 18823/20000, Loss: 0,002258717414198326
            Epoch 18824/20000, Loss: 0,0022585946100054503
            Epoch 18825/20000, Loss: 0,002258471817772978
            Epoch 18826/20000, Loss: 0,0022583490374992886
            Epoch 18827/20000, Loss: 0,0022582262691827615
            Epoch 18828/20000, Loss: 0,0022581035128217738
            Epoch 18829/20000, Loss: 0,0022579807684147083
            Epoch 18830/20000, Loss: 0,0022578580359599435
            Epoch 18831/20000, Loss: 0,0022577353154558605
            Epoch 18832/20000, Loss: 0,0022576126069008395
            Epoch 18833/20000, Loss: 0,0022574899102932606
            Epoch 18834/20000, Loss: 0,002257367225631507
            Epoch 18835/20000, Loss: 0,002257244552913959
            Epoch 18836/20000, Loss: 0,002257121892139001
            Epoch 18837/20000, Loss: 0,0022569992433050107
            Epoch 18838/20000, Loss: 0,0022568766064103747
            Epoch 18839/20000, Loss: 0,002256753981453474
            Epoch 18840/20000, Loss: 0,002256631368432693
            Epoch 18841/20000, Loss: 0,0022565087673464142
            Epoch 18842/20000, Loss: 0,002256386178193021
            Epoch 18843/20000, Loss: 0,0022562636009708986
            Epoch 18844/20000, Loss: 0,0022561410356784313
            Epoch 18845/20000, Loss: 0,002256018482314004
            Epoch 18846/20000, Loss: 0,0022558959408760008
            Epoch 18847/20000, Loss: 0,0022557734113628075
            Epoch 18848/20000, Loss: 0,002255650893772812
            Epoch 18849/20000, Loss: 0,002255528388104398
            Epoch 18850/20000, Loss: 0,0022554058943559515
            Epoch 18851/20000, Loss: 0,0022552834125258605
            Epoch 18852/20000, Loss: 0,0022551609426125115
            Epoch 18853/20000, Loss: 0,0022550384846142914
            Epoch 18854/20000, Loss: 0,002254916038529588
            Epoch 18855/20000, Loss: 0,0022547936043567896
            Epoch 18856/20000, Loss: 0,002254671182094284
            Epoch 18857/20000, Loss: 0,00225454877174046
            Epoch 18858/20000, Loss: 0,0022544263732937058
            Epoch 18859/20000, Loss: 0,0022543039867524107
            Epoch 18860/20000, Loss: 0,0022541816121149647
            Epoch 18861/20000, Loss: 0,0022540592493797587
            Epoch 18862/20000, Loss: 0,0022539368985451795
            Epoch 18863/20000, Loss: 0,0022538145596096215
            Epoch 18864/20000, Loss: 0,0022536922325714715
            Epoch 18865/20000, Loss: 0,002253569917429124
            Epoch 18866/20000, Loss: 0,0022534476141809674
            Epoch 18867/20000, Loss: 0,002253325322825396
            Epoch 18868/20000, Loss: 0,0022532030433608
            Epoch 18869/20000, Loss: 0,0022530807757855714
            Epoch 18870/20000, Loss: 0,0022529585200981037
            Epoch 18871/20000, Loss: 0,0022528362762967895
            Epoch 18872/20000, Loss: 0,0022527140443800225
            Epoch 18873/20000, Loss: 0,0022525918243461954
            Epoch 18874/20000, Loss: 0,0022524696161937033
            Epoch 18875/20000, Loss: 0,0022523474199209383
            Epoch 18876/20000, Loss: 0,0022522252355262956
            Epoch 18877/20000, Loss: 0,0022521030630081717
            Epoch 18878/20000, Loss: 0,0022519809023649603
            Epoch 18879/20000, Loss: 0,0022518587535950564
            Epoch 18880/20000, Loss: 0,0022517366166968553
            Epoch 18881/20000, Loss: 0,0022516144916687555
            Epoch 18882/20000, Loss: 0,00225149237850915
            Epoch 18883/20000, Loss: 0,002251370277216438
            Epoch 18884/20000, Loss: 0,0022512481877890156
            Epoch 18885/20000, Loss: 0,0022511261102252786
            Epoch 18886/20000, Loss: 0,002251004044523628
            Epoch 18887/20000, Loss: 0,0022508819906824577
            Epoch 18888/20000, Loss: 0,0022507599487001694
            Epoch 18889/20000, Loss: 0,002250637918575158
            Epoch 18890/20000, Loss: 0,0022505159003058254
            Epoch 18891/20000, Loss: 0,002250393893890568
            Epoch 18892/20000, Loss: 0,0022502718993277888
            Epoch 18893/20000, Loss: 0,002250149916615885
            Epoch 18894/20000, Loss: 0,002250027945753256
            Epoch 18895/20000, Loss: 0,002249905986738305
            Epoch 18896/20000, Loss: 0,0022497840395694297
            Epoch 18897/20000, Loss: 0,0022496621042450327
            Epoch 18898/20000, Loss: 0,0022495401807635135
            Epoch 18899/20000, Loss: 0,0022494182691232775
            Epoch 18900/20000, Loss: 0,002249296369322722
            Epoch 18901/20000, Loss: 0,002249174481360252
            Epoch 18902/20000, Loss: 0,0022490526052342695
            Epoch 18903/20000, Loss: 0,0022489307409431776
            Epoch 18904/20000, Loss: 0,0022488088884853783
            Epoch 18905/20000, Loss: 0,0022486870478592757
            Epoch 18906/20000, Loss: 0,0022485652190632737
            Epoch 18907/20000, Loss: 0,002248443402095777
            Epoch 18908/20000, Loss: 0,0022483215969551886
            Epoch 18909/20000, Loss: 0,002248199803639914
            Epoch 18910/20000, Loss: 0,002248078022148357
            Epoch 18911/20000, Loss: 0,0022479562524789247
            Epoch 18912/20000, Loss: 0,0022478344946300225
            Epoch 18913/20000, Loss: 0,002247712748600055
            Epoch 18914/20000, Loss: 0,00224759101438743
            Epoch 18915/20000, Loss: 0,0022474692919905517
            Epoch 18916/20000, Loss: 0,002247347581407828
            Epoch 18917/20000, Loss: 0,0022472258826376685
            Epoch 18918/20000, Loss: 0,002247104195678478
            Epoch 18919/20000, Loss: 0,0022469825205286642
            Epoch 18920/20000, Loss: 0,002246860857186636
            Epoch 18921/20000, Loss: 0,0022467392056508017
            Epoch 18922/20000, Loss: 0,00224661756591957
            Epoch 18923/20000, Loss: 0,0022464959379913494
            Epoch 18924/20000, Loss: 0,0022463743218645487
            Epoch 18925/20000, Loss: 0,002246252717537581
            Epoch 18926/20000, Loss: 0,0022461311250088524
            Epoch 18927/20000, Loss: 0,0022460095442767745
            Epoch 18928/20000, Loss: 0,0022458879753397567
            Epoch 18929/20000, Loss: 0,0022457664181962118
            Epoch 18930/20000, Loss: 0,002245644872844548
            Epoch 18931/20000, Loss: 0,0022455233392831815
            Epoch 18932/20000, Loss: 0,002245401817510521
            Epoch 18933/20000, Loss: 0,002245280307524978
            Epoch 18934/20000, Loss: 0,0022451588093249653
            Epoch 18935/20000, Loss: 0,002245037322908897
            Epoch 18936/20000, Loss: 0,0022449158482751837
            Epoch 18937/20000, Loss: 0,0022447943854222415
            Epoch 18938/20000, Loss: 0,0022446729343484828
            Epoch 18939/20000, Loss: 0,0022445514950523208
            Epoch 18940/20000, Loss: 0,0022444300675321703
            Epoch 18941/20000, Loss: 0,002244308651786446
            Epoch 18942/20000, Loss: 0,0022441872478135626
            Epoch 18943/20000, Loss: 0,0022440658556119345
            Epoch 18944/20000, Loss: 0,002243944475179978
            Epoch 18945/20000, Loss: 0,0022438231065161104
            Epoch 18946/20000, Loss: 0,0022437017496187445
            Epoch 18947/20000, Loss: 0,002243580404486299
            Epoch 18948/20000, Loss: 0,0022434590711171887
            Epoch 18949/20000, Loss: 0,0022433377495098333
            Epoch 18950/20000, Loss: 0,0022432164396626454
            Epoch 18951/20000, Loss: 0,0022430951415740494
            Epoch 18952/20000, Loss: 0,0022429738552424573
            Epoch 18953/20000, Loss: 0,00224285258066629
            Epoch 18954/20000, Loss: 0,0022427313178439664
            Epoch 18955/20000, Loss: 0,002242610066773903
            Epoch 18956/20000, Loss: 0,0022424888274545206
            Epoch 18957/20000, Loss: 0,002242367599884239
            Epoch 18958/20000, Loss: 0,0022422463840614756
            Epoch 18959/20000, Loss: 0,002242125179984654
            Epoch 18960/20000, Loss: 0,002242003987652192
            Epoch 18961/20000, Loss: 0,0022418828070625116
            Epoch 18962/20000, Loss: 0,002241761638214033
            Epoch 18963/20000, Loss: 0,0022416404811051757
            Epoch 18964/20000, Loss: 0,0022415193357343643
            Epoch 18965/20000, Loss: 0,0022413982021000202
            Epoch 18966/20000, Loss: 0,0022412770802005644
            Epoch 18967/20000, Loss: 0,00224115597003442
            Epoch 18968/20000, Loss: 0,0022410348716000086
            Epoch 18969/20000, Loss: 0,002240913784895755
            Epoch 18970/20000, Loss: 0,0022407927099200816
            Epoch 18971/20000, Loss: 0,002240671646671414
            Epoch 18972/20000, Loss: 0,0022405505951481725
            Epoch 18973/20000, Loss: 0,0022404295553487843
            Epoch 18974/20000, Loss: 0,0022403085272716733
            Epoch 18975/20000, Loss: 0,0022401875109152648
            Epoch 18976/20000, Loss: 0,002240066506277984
            Epoch 18977/20000, Loss: 0,0022399455133582545
            Epoch 18978/20000, Loss: 0,0022398245321545054
            Epoch 18979/20000, Loss: 0,002239703562665161
            Epoch 18980/20000, Loss: 0,0022395826048886465
            Epoch 18981/20000, Loss: 0,0022394616588233907
            Epoch 18982/20000, Loss: 0,0022393407244678193
            Epoch 18983/20000, Loss: 0,002239219801820361
            Epoch 18984/20000, Loss: 0,0022390988908794424
            Epoch 18985/20000, Loss: 0,0022389779916434926
            Epoch 18986/20000, Loss: 0,002238857104110938
            Epoch 18987/20000, Loss: 0,002238736228280209
            Epoch 18988/20000, Loss: 0,002238615364149733
            Epoch 18989/20000, Loss: 0,0022384945117179416
            Epoch 18990/20000, Loss: 0,0022383736709832612
            Epoch 18991/20000, Loss: 0,0022382528419441234
            Epoch 18992/20000, Loss: 0,0022381320245989577
            Epoch 18993/20000, Loss: 0,0022380112189461948
            Epoch 18994/20000, Loss: 0,002237890424984264
            Epoch 18995/20000, Loss: 0,0022377696427115993
            Epoch 18996/20000, Loss: 0,0022376488721266297
            Epoch 18997/20000, Loss: 0,0022375281132277873
            Epoch 18998/20000, Loss: 0,002237407366013503
            Epoch 18999/20000, Loss: 0,002237286630482211
            Epoch 19000/20000, Loss: 0,002237165906632343
            Epoch 19001/20000, Loss: 0,0022370451944623317
            Epoch 19002/20000, Loss: 0,0022369244939706096
            Epoch 19003/20000, Loss: 0,0022368038051556105
            Epoch 19004/20000, Loss: 0,00223668312801577
            Epoch 19005/20000, Loss: 0,0022365624625495183
            Epoch 19006/20000, Loss: 0,0022364418087552937
            Epoch 19007/20000, Loss: 0,0022363211666315283
            Epoch 19008/20000, Loss: 0,002236200536176657
            Epoch 19009/20000, Loss: 0,002236079917389117
            Epoch 19010/20000, Loss: 0,002235959310267343
            Epoch 19011/20000, Loss: 0,002235838714809769
            Epoch 19012/20000, Loss: 0,0022357181310148334
            Epoch 19013/20000, Loss: 0,002235597558880971
            Epoch 19014/20000, Loss: 0,00223547699840662
            Epoch 19015/20000, Loss: 0,002235356449590216
            Epoch 19016/20000, Loss: 0,0022352359124301977
            Epoch 19017/20000, Loss: 0,0022351153869250026
            Epoch 19018/20000, Loss: 0,0022349948730730697
            Epoch 19019/20000, Loss: 0,0022348743708728346
            Epoch 19020/20000, Loss: 0,0022347538803227356
            Epoch 19021/20000, Loss: 0,0022346334014212146
            Epoch 19022/20000, Loss: 0,0022345129341667094
            Epoch 19023/20000, Loss: 0,0022343924785576588
            Epoch 19024/20000, Loss: 0,0022342720345925023
            Epoch 19025/20000, Loss: 0,00223415160226968
            Epoch 19026/20000, Loss: 0,0022340311815876347
            Epoch 19027/20000, Loss: 0,0022339107725448054
            Epoch 19028/20000, Loss: 0,0022337903751396314
            Epoch 19029/20000, Loss: 0,002233669989370557
            Epoch 19030/20000, Loss: 0,0022335496152360206
            Epoch 19031/20000, Loss: 0,002233429252734468
            Epoch 19032/20000, Loss: 0,0022333089018643374
            Epoch 19033/20000, Loss: 0,002233188562624073
            Epoch 19034/20000, Loss: 0,002233068235012118
            Epoch 19035/20000, Loss: 0,002232947919026915
            Epoch 19036/20000, Loss: 0,0022328276146669065
            Epoch 19037/20000, Loss: 0,0022327073219305374
            Epoch 19038/20000, Loss: 0,0022325870408162526
            Epoch 19039/20000, Loss: 0,0022324667713224935
            Epoch 19040/20000, Loss: 0,0022323465134477054
            Epoch 19041/20000, Loss: 0,0022322262671903366
            Epoch 19042/20000, Loss: 0,0022321060325488275
            Epoch 19043/20000, Loss: 0,0022319858095216265
            Epoch 19044/20000, Loss: 0,0022318655981071788
            Epoch 19045/20000, Loss: 0,002231745398303931
            Epoch 19046/20000, Loss: 0,0022316252101103277
            Epoch 19047/20000, Loss: 0,0022315050335248157
            Epoch 19048/20000, Loss: 0,002231384868545844
            Epoch 19049/20000, Loss: 0,0022312647151718585
            Epoch 19050/20000, Loss: 0,0022311445734013078
            Epoch 19051/20000, Loss: 0,0022310244432326375
            Epoch 19052/20000, Loss: 0,002230904324664297
            Epoch 19053/20000, Loss: 0,002230784217694736
            Epoch 19054/20000, Loss: 0,002230664122322402
            Epoch 19055/20000, Loss: 0,0022305440385457444
            Epoch 19056/20000, Loss: 0,002230423966363211
            Epoch 19057/20000, Loss: 0,0022303039057732545
            Epoch 19058/20000, Loss: 0,0022301838567743222
            Epoch 19059/20000, Loss: 0,002230063819364867
            Epoch 19060/20000, Loss: 0,0022299437935433355
            Epoch 19061/20000, Loss: 0,002229823779308183
            Epoch 19062/20000, Loss: 0,002229703776657857
            Epoch 19063/20000, Loss: 0,0022295837855908105
            Epoch 19064/20000, Loss: 0,0022294638061054967
            Epoch 19065/20000, Loss: 0,0022293438382003654
            Epoch 19066/20000, Loss: 0,00222922388187387
            Epoch 19067/20000, Loss: 0,0022291039371244614
            Epoch 19068/20000, Loss: 0,0022289840039505953
            Epoch 19069/20000, Loss: 0,002228864082350723
            Epoch 19070/20000, Loss: 0,002228744172323299
            Epoch 19071/20000, Loss: 0,002228624273866777
            Epoch 19072/20000, Loss: 0,00222850438697961
            Epoch 19073/20000, Loss: 0,002228384511660254
            Epoch 19074/20000, Loss: 0,002228264647907163
            Epoch 19075/20000, Loss: 0,0022281447957187917
            Epoch 19076/20000, Loss: 0,0022280249550935965
            Epoch 19077/20000, Loss: 0,0022279051260300315
            Epoch 19078/20000, Loss: 0,002227785308526553
            Epoch 19079/20000, Loss: 0,0022276655025816198
            Epoch 19080/20000, Loss: 0,0022275457081936847
            Epoch 19081/20000, Loss: 0,002227425925361207
            Epoch 19082/20000, Loss: 0,002227306154082641
            Epoch 19083/20000, Loss: 0,002227186394356448
            Epoch 19084/20000, Loss: 0,0022270666461810824
            Epoch 19085/20000, Loss: 0,002226946909555004
            Epoch 19086/20000, Loss: 0,002226827184476669
            Epoch 19087/20000, Loss: 0,002226707470944541
            Epoch 19088/20000, Loss: 0,002226587768957073
            Epoch 19089/20000, Loss: 0,0022264680785127255
            Epoch 19090/20000, Loss: 0,00222634839960996
            Epoch 19091/20000, Loss: 0,0022262287322472357
            Epoch 19092/20000, Loss: 0,002226109076423012
            Epoch 19093/20000, Loss: 0,002225989432135751
            Epoch 19094/20000, Loss: 0,00222586979938391
            Epoch 19095/20000, Loss: 0,0022257501781659528
            Epoch 19096/20000, Loss: 0,0022256305684803393
            Epoch 19097/20000, Loss: 0,002225510970325531
            Epoch 19098/20000, Loss: 0,002225391383699991
            Epoch 19099/20000, Loss: 0,00222527180860218
            Epoch 19100/20000, Loss: 0,0022251522450305616
            Epoch 19101/20000, Loss: 0,002225032692983598
            Epoch 19102/20000, Loss: 0,0022249131524597525
            Epoch 19103/20000, Loss: 0,002224793623457487
            Epoch 19104/20000, Loss: 0,0022246741059752683
            Epoch 19105/20000, Loss: 0,0022245546000115557
            Epoch 19106/20000, Loss: 0,0022244351055648176
            Epoch 19107/20000, Loss: 0,002224315622633518
            Epoch 19108/20000, Loss: 0,002224196151216118
            Epoch 19109/20000, Loss: 0,002224076691311087
            Epoch 19110/20000, Loss: 0,002223957242916888
            Epoch 19111/20000, Loss: 0,002223837806031988
            Epoch 19112/20000, Loss: 0,002223718380654852
            Epoch 19113/20000, Loss: 0,0022235989667839474
            Epoch 19114/20000, Loss: 0,002223479564417738
            Epoch 19115/20000, Loss: 0,0022233601735546947
            Epoch 19116/20000, Loss: 0,002223240794193282
            Epoch 19117/20000, Loss: 0,002223121426331968
            Epoch 19118/20000, Loss: 0,00222300206996922
            Epoch 19119/20000, Loss: 0,0022228827251035066
            Epoch 19120/20000, Loss: 0,002222763391733297
            Epoch 19121/20000, Loss: 0,002222644069857057
            Epoch 19122/20000, Loss: 0,002222524759473258
            Epoch 19123/20000, Loss: 0,0022224054605803683
            Epoch 19124/20000, Loss: 0,0022222861731768582
            Epoch 19125/20000, Loss: 0,0022221668972611974
            Epoch 19126/20000, Loss: 0,002222047632831854
            Epoch 19127/20000, Loss: 0,002221928379887301
            Epoch 19128/20000, Loss: 0,0022218091384260084
            Epoch 19129/20000, Loss: 0,0022216899084464463
            Epoch 19130/20000, Loss: 0,0022215706899470873
            Epoch 19131/20000, Loss: 0,0022214514829264
            Epoch 19132/20000, Loss: 0,00222133228738286
            Epoch 19133/20000, Loss: 0,0022212131033149383
            Epoch 19134/20000, Loss: 0,0022210939307211065
            Epoch 19135/20000, Loss: 0,0022209747695998367
            Epoch 19136/20000, Loss: 0,002220855619949604
            Epoch 19137/20000, Loss: 0,0022207364817688814
            Epoch 19138/20000, Loss: 0,0022206173550561397
            Epoch 19139/20000, Loss: 0,0022204982398098564
            Epoch 19140/20000, Loss: 0,002220379136028504
            Epoch 19141/20000, Loss: 0,0022202600437105577
            Epoch 19142/20000, Loss: 0,002220140962854491
            Epoch 19143/20000, Loss: 0,002220021893458781
            Epoch 19144/20000, Loss: 0,0022199028355219
            Epoch 19145/20000, Loss: 0,0022197837890423266
            Epoch 19146/20000, Loss: 0,0022196647540185365
            Epoch 19147/20000, Loss: 0,002219545730449004
            Epoch 19148/20000, Loss: 0,002219426718332207
            Epoch 19149/20000, Loss: 0,0022193077176666225
            Epoch 19150/20000, Loss: 0,0022191887284507277
            Epoch 19151/20000, Loss: 0,002219069750682998
            Epoch 19152/20000, Loss: 0,002218950784361913
            Epoch 19153/20000, Loss: 0,002218831829485952
            Epoch 19154/20000, Loss: 0,00221871288605359
            Epoch 19155/20000, Loss: 0,002218593954063308
            Epoch 19156/20000, Loss: 0,0022184750335135827
            Epoch 19157/20000, Loss: 0,002218356124402898
            Epoch 19158/20000, Loss: 0,0022182372267297275
            Epoch 19159/20000, Loss: 0,002218118340492555
            Epoch 19160/20000, Loss: 0,0022179994656898565
            Epoch 19161/20000, Loss: 0,002217880602320118
            Epoch 19162/20000, Loss: 0,0022177617503818144
            Epoch 19163/20000, Loss: 0,00221764290987343
            Epoch 19164/20000, Loss: 0,0022175240807934477
            Epoch 19165/20000, Loss: 0,0022174052631403433
            Epoch 19166/20000, Loss: 0,0022172864569126034
            Epoch 19167/20000, Loss: 0,0022171676621087085
            Epoch 19168/20000, Loss: 0,0022170488787271415
            Epoch 19169/20000, Loss: 0,002216930106766383
            Epoch 19170/20000, Loss: 0,002216811346224918
            Epoch 19171/20000, Loss: 0,0022166925971012297
            Epoch 19172/20000, Loss: 0,0022165738593938012
            Epoch 19173/20000, Loss: 0,002216455133101116
            Epoch 19174/20000, Loss: 0,002216336418221659
            Epoch 19175/20000, Loss: 0,002216217714753914
            Epoch 19176/20000, Loss: 0,0022160990226963656
            Epoch 19177/20000, Loss: 0,002215980342047498
            Epoch 19178/20000, Loss: 0,0022158616728057993
            Epoch 19179/20000, Loss: 0,002215743014969753
            Epoch 19180/20000, Loss: 0,0022156243685378433
            Epoch 19181/20000, Loss: 0,0022155057335085586
            Epoch 19182/20000, Loss: 0,0022153871098803866
            Epoch 19183/20000, Loss: 0,0022152684976518124
            Epoch 19184/20000, Loss: 0,0022151498968213212
            Epoch 19185/20000, Loss: 0,002215031307387404
            Epoch 19186/20000, Loss: 0,0022149127293485445
            Epoch 19187/20000, Loss: 0,0022147941627032332
            Epoch 19188/20000, Loss: 0,002214675607449959
            Epoch 19189/20000, Loss: 0,0022145570635872082
            Epoch 19190/20000, Loss: 0,002214438531113469
            Epoch 19191/20000, Loss: 0,002214320010027234
            Epoch 19192/20000, Loss: 0,002214201500326989
            Epoch 19193/20000, Loss: 0,002214083002011225
            Epoch 19194/20000, Loss: 0,0022139645150784314
            Epoch 19195/20000, Loss: 0,0022138460395270993
            Epoch 19196/20000, Loss: 0,0022137275753557188
            Epoch 19197/20000, Loss: 0,002213609122562781
            Epoch 19198/20000, Loss: 0,002213490681146775
            Epoch 19199/20000, Loss: 0,002213372251106194
            Epoch 19200/20000, Loss: 0,002213253832439531
            Epoch 19201/20000, Loss: 0,0022131354251452738
            Epoch 19202/20000, Loss: 0,0022130170292219186
            Epoch 19203/20000, Loss: 0,002212898644667956
            Epoch 19204/20000, Loss: 0,002212780271481878
            Epoch 19205/20000, Loss: 0,0022126619096621805
            Epoch 19206/20000, Loss: 0,002212543559207354
            Epoch 19207/20000, Loss: 0,0022124252201158935
            Epoch 19208/20000, Loss: 0,002212306892386293
            Epoch 19209/20000, Loss: 0,0022121885760170456
            Epoch 19210/20000, Loss: 0,0022120702710066473
            Epoch 19211/20000, Loss: 0,002211951977353592
            Epoch 19212/20000, Loss: 0,0022118336950563747
            Epoch 19213/20000, Loss: 0,002211715424113493
            Epoch 19214/20000, Loss: 0,002211597164523438
            Epoch 19215/20000, Loss: 0,0022114789162847094
            Epoch 19216/20000, Loss: 0,0022113606793958025
            Epoch 19217/20000, Loss: 0,002211242453855213
            Epoch 19218/20000, Loss: 0,0022111242396614383
            Epoch 19219/20000, Loss: 0,0022110060368129764
            Epoch 19220/20000, Loss: 0,002210887845308324
            Epoch 19221/20000, Loss: 0,0022107696651459774
            Epoch 19222/20000, Loss: 0,0022106514963244374
            Epoch 19223/20000, Loss: 0,002210533338842199
            Epoch 19224/20000, Loss: 0,0022104151926977634
            Epoch 19225/20000, Loss: 0,0022102970578896275
            Epoch 19226/20000, Loss: 0,002210178934416292
            Epoch 19227/20000, Loss: 0,0022100608222762547
            Epoch 19228/20000, Loss: 0,0022099427214680176
            Epoch 19229/20000, Loss: 0,0022098246319900774
            Epoch 19230/20000, Loss: 0,0022097065538409367
            Epoch 19231/20000, Loss: 0,0022095884870190945
            Epoch 19232/20000, Loss: 0,002209470431523054
            Epoch 19233/20000, Loss: 0,0022093523873513146
            Epoch 19234/20000, Loss: 0,002209234354502377
            Epoch 19235/20000, Loss: 0,0022091163329747447
            Epoch 19236/20000, Loss: 0,0022089983227669184
            Epoch 19237/20000, Loss: 0,0022088803238774005
            Epoch 19238/20000, Loss: 0,0022087623363046946
            Epoch 19239/20000, Loss: 0,002208644360047302
            Epoch 19240/20000, Loss: 0,002208526395103727
            Epoch 19241/20000, Loss: 0,0022084084414724717
            Epoch 19242/20000, Loss: 0,0022082904991520417
            Epoch 19243/20000, Loss: 0,002208172568140939
            Epoch 19244/20000, Loss: 0,0022080546484376674
            Epoch 19245/20000, Loss: 0,0022079367400407337
            Epoch 19246/20000, Loss: 0,0022078188429486426
            Epoch 19247/20000, Loss: 0,0022077009571598973
            Epoch 19248/20000, Loss: 0,0022075830826730034
            Epoch 19249/20000, Loss: 0,0022074652194864685
            Epoch 19250/20000, Loss: 0,002207347367598796
            Epoch 19251/20000, Loss: 0,002207229527008495
            Epoch 19252/20000, Loss: 0,0022071116977140696
            Epoch 19253/20000, Loss: 0,0022069938797140273
            Epoch 19254/20000, Loss: 0,0022068760730068753
            Epoch 19255/20000, Loss: 0,0022067582775911216
            Epoch 19256/20000, Loss: 0,0022066404934652723
            Epoch 19257/20000, Loss: 0,0022065227206278367
            Epoch 19258/20000, Loss: 0,0022064049590773227
            Epoch 19259/20000, Loss: 0,0022062872088122387
            Epoch 19260/20000, Loss: 0,002206169469831094
            Epoch 19261/20000, Loss: 0,0022060517421323986
            Epoch 19262/20000, Loss: 0,0022059340257146584
            Epoch 19263/20000, Loss: 0,002205816320576385
            Epoch 19264/20000, Loss: 0,0022056986267160886
            Epoch 19265/20000, Loss: 0,0022055809441322797
            Epoch 19266/20000, Loss: 0,002205463272823468
            Epoch 19267/20000, Loss: 0,002205345612788164
            Epoch 19268/20000, Loss: 0,0022052279640248805
            Epoch 19269/20000, Loss: 0,0022051103265321266
            Epoch 19270/20000, Loss: 0,002204992700308416
            Epoch 19271/20000, Loss: 0,0022048750853522585
            Epoch 19272/20000, Loss: 0,0022047574816621675
            Epoch 19273/20000, Loss: 0,002204639889236656
            Epoch 19274/20000, Loss: 0,002204522308074236
            Epoch 19275/20000, Loss: 0,00220440473817342
            Epoch 19276/20000, Loss: 0,002204287179532723
            Epoch 19277/20000, Loss: 0,0022041696321506562
            Epoch 19278/20000, Loss: 0,0022040520960257353
            Epoch 19279/20000, Loss: 0,002203934571156475
            Epoch 19280/20000, Loss: 0,002203817057541387
            Epoch 19281/20000, Loss: 0,0022036995551789882
            Epoch 19282/20000, Loss: 0,0022035820640677944
            Epoch 19283/20000, Loss: 0,002203464584206318
            Epoch 19284/20000, Loss: 0,0022033471155930764
            Epoch 19285/20000, Loss: 0,0022032296582265866
            Epoch 19286/20000, Loss: 0,002203112212105363
            Epoch 19287/20000, Loss: 0,002202994777227921
            Epoch 19288/20000, Loss: 0,0022028773535927807
            Epoch 19289/20000, Loss: 0,0022027599411984554
            Epoch 19290/20000, Loss: 0,002202642540043465
            Epoch 19291/20000, Loss: 0,002202525150126325
            Epoch 19292/20000, Loss: 0,002202407771445555
            Epoch 19293/20000, Loss: 0,0022022904039996727
            Epoch 19294/20000, Loss: 0,002202173047787197
            Epoch 19295/20000, Loss: 0,002202055702806644
            Epoch 19296/20000, Loss: 0,002201938369056536
            Epoch 19297/20000, Loss: 0,0022018210465353893
            Epoch 19298/20000, Loss: 0,0022017037352417253
            Epoch 19299/20000, Loss: 0,0022015864351740628
            Epoch 19300/20000, Loss: 0,0022014691463309232
            Epoch 19301/20000, Loss: 0,0022013518687108253
            Epoch 19302/20000, Loss: 0,00220123460231229
            Epoch 19303/20000, Loss: 0,002201117347133838
            Epoch 19304/20000, Loss: 0,002201000103173994
            Epoch 19305/20000, Loss: 0,002200882870431274
            Epoch 19306/20000, Loss: 0,0022007656489042046
            Epoch 19307/20000, Loss: 0,0022006484385913025
            Epoch 19308/20000, Loss: 0,002200531239491095
            Epoch 19309/20000, Loss: 0,002200414051602102
            Epoch 19310/20000, Loss: 0,002200296874922847
            Epoch 19311/20000, Loss: 0,002200179709451853
            Epoch 19312/20000, Loss: 0,002200062555187646
            Epoch 19313/20000, Loss: 0,0021999454121287452
            Epoch 19314/20000, Loss: 0,0021998282802736776
            Epoch 19315/20000, Loss: 0,0021997111596209658
            Epoch 19316/20000, Loss: 0,0021995940501691354
            Epoch 19317/20000, Loss: 0,0021994769519167105
            Epoch 19318/20000, Loss: 0,00219935986486222
            Epoch 19319/20000, Loss: 0,0021992427890041824
            Epoch 19320/20000, Loss: 0,002199125724341128
            Epoch 19321/20000, Loss: 0,002199008670871582
            Epoch 19322/20000, Loss: 0,0021988916285940693
            Epoch 19323/20000, Loss: 0,0021987745975071194
            Epoch 19324/20000, Loss: 0,0021986575776092553
            Epoch 19325/20000, Loss: 0,0021985405688990075
            Epoch 19326/20000, Loss: 0,0021984235713748993
            Epoch 19327/20000, Loss: 0,0021983065850354638
            Epoch 19328/20000, Loss: 0,002198189609879223
            Epoch 19329/20000, Loss: 0,00219807264590471
            Epoch 19330/20000, Loss: 0,0021979556931104485
            Epoch 19331/20000, Loss: 0,002197838751494973
            Epoch 19332/20000, Loss: 0,002197721821056807
            Epoch 19333/20000, Loss: 0,0021976049017944825
            Epoch 19334/20000, Loss: 0,0021974879937065304
            Epoch 19335/20000, Loss: 0,002197371096791477
            Epoch 19336/20000, Loss: 0,002197254211047854
            Epoch 19337/20000, Loss: 0,0021971373364741936
            Epoch 19338/20000, Loss: 0,002197020473069024
            Epoch 19339/20000, Loss: 0,002196903620830877
            Epoch 19340/20000, Loss: 0,002196786779758285
            Epoch 19341/20000, Loss: 0,0021966699498497766
            Epoch 19342/20000, Loss: 0,0021965531311038864
            Epoch 19343/20000, Loss: 0,002196436323519145
            Epoch 19344/20000, Loss: 0,002196319527094085
            Epoch 19345/20000, Loss: 0,0021962027418272402
            Epoch 19346/20000, Loss: 0,002196085967717142
            Epoch 19347/20000, Loss: 0,002195969204762324
            Epoch 19348/20000, Loss: 0,0021958524529613176
            Epoch 19349/20000, Loss: 0,002195735712312662
            Epoch 19350/20000, Loss: 0,0021956189828148853
            Epoch 19351/20000, Loss: 0,0021955022644665253
            Epoch 19352/20000, Loss: 0,0021953855572661154
            Epoch 19353/20000, Loss: 0,0021952688612121895
            Epoch 19354/20000, Loss: 0,0021951521763032855
            Epoch 19355/20000, Loss: 0,0021950355025379354
            Epoch 19356/20000, Loss: 0,002194918839914677
            Epoch 19357/20000, Loss: 0,0021948021884320443
            Epoch 19358/20000, Loss: 0,002194685548088576
            Epoch 19359/20000, Loss: 0,0021945689188828084
            Epoch 19360/20000, Loss: 0,002194452300813277
            Epoch 19361/20000, Loss: 0,0021943356938785175
            Epoch 19362/20000, Loss: 0,002194219098077071
            Epoch 19363/20000, Loss: 0,0021941025134074718
            Epoch 19364/20000, Loss: 0,0021939859398682577
            Epoch 19365/20000, Loss: 0,0021938693774579696
            Epoch 19366/20000, Loss: 0,002193752826175143
            Epoch 19367/20000, Loss: 0,00219363628601832
            Epoch 19368/20000, Loss: 0,0021935197569860356
            Epoch 19369/20000, Loss: 0,0021934032390768317
            Epoch 19370/20000, Loss: 0,0021932867322892466
            Epoch 19371/20000, Loss: 0,0021931702366218193
            Epoch 19372/20000, Loss: 0,0021930537520730925
            Epoch 19373/20000, Loss: 0,0021929372786416044
            Epoch 19374/20000, Loss: 0,002192820816325897
            Epoch 19375/20000, Loss: 0,00219270436512451
            Epoch 19376/20000, Loss: 0,002192587925035985
            Epoch 19377/20000, Loss: 0,0021924714960588633
            Epoch 19378/20000, Loss: 0,0021923550781916866
            Epoch 19379/20000, Loss: 0,0021922386714329973
            Epoch 19380/20000, Loss: 0,0021921222757813373
            Epoch 19381/20000, Loss: 0,002192005891235248
            Epoch 19382/20000, Loss: 0,002191889517793275
            Epoch 19383/20000, Loss: 0,002191773155453959
            Epoch 19384/20000, Loss: 0,002191656804215845
            Epoch 19385/20000, Loss: 0,0021915404640774736
            Epoch 19386/20000, Loss: 0,0021914241350373927
            Epoch 19387/20000, Loss: 0,002191307817094144
            Epoch 19388/20000, Loss: 0,0021911915102462726
            Epoch 19389/20000, Loss: 0,0021910752144923234
            Epoch 19390/20000, Loss: 0,00219095892983084
            Epoch 19391/20000, Loss: 0,002190842656260371
            Epoch 19392/20000, Loss: 0,002190726393779458
            Epoch 19393/20000, Loss: 0,0021906101423866476
            Epoch 19394/20000, Loss: 0,002190493902080489
            Epoch 19395/20000, Loss: 0,002190377672859525
            Epoch 19396/20000, Loss: 0,0021902614547223034
            Epoch 19397/20000, Loss: 0,002190145247667373
            Epoch 19398/20000, Loss: 0,0021900290516932773
            Epoch 19399/20000, Loss: 0,0021899128667985665
            Epoch 19400/20000, Loss: 0,0021897966929817873
            Epoch 19401/20000, Loss: 0,002189680530241489
            Epoch 19402/20000, Loss: 0,002189564378576218
            Epoch 19403/20000, Loss: 0,002189448237984523
            Epoch 19404/20000, Loss: 0,002189332108464954
            Epoch 19405/20000, Loss: 0,00218921599001606
            Epoch 19406/20000, Loss: 0,0021890998826363892
            Epoch 19407/20000, Loss: 0,0021889837863244914
            Epoch 19408/20000, Loss: 0,0021888677010789177
            Epoch 19409/20000, Loss: 0,0021887516268982174
            Epoch 19410/20000, Loss: 0,0021886355637809407
            Epoch 19411/20000, Loss: 0,0021885195117256396
            Epoch 19412/20000, Loss: 0,0021884034707308625
            Epoch 19413/20000, Loss: 0,002188287440795164
            Epoch 19414/20000, Loss: 0,0021881714219170924
            Epoch 19415/20000, Loss: 0,002188055414095202
            Epoch 19416/20000, Loss: 0,0021879394173280444
            Epoch 19417/20000, Loss: 0,00218782343161417
            Epoch 19418/20000, Loss: 0,0021877074569521342
            Epoch 19419/20000, Loss: 0,0021875914933404874
            Epoch 19420/20000, Loss: 0,0021874755407777845
            Epoch 19421/20000, Loss: 0,0021873595992625778
            Epoch 19422/20000, Loss: 0,002187243668793422
            Epoch 19423/20000, Loss: 0,0021871277493688704
            Epoch 19424/20000, Loss: 0,0021870118409874784
            Epoch 19425/20000, Loss: 0,0021868959436477965
            Epoch 19426/20000, Loss: 0,002186780057348385
            Epoch 19427/20000, Loss: 0,002186664182087795
            Epoch 19428/20000, Loss: 0,0021865483178645853
            Epoch 19429/20000, Loss: 0,0021864324646773082
            Epoch 19430/20000, Loss: 0,00218631662252452
            Epoch 19431/20000, Loss: 0,0021862007914047778
            Epoch 19432/20000, Loss: 0,0021860849713166383
            Epoch 19433/20000, Loss: 0,0021859691622586573
            Epoch 19434/20000, Loss: 0,002185853364229392
            Epoch 19435/20000, Loss: 0,0021857375772273992
            Epoch 19436/20000, Loss: 0,002185621801251238
            Epoch 19437/20000, Loss: 0,0021855060362994646
            Epoch 19438/20000, Loss: 0,002185390282370637
            Epoch 19439/20000, Loss: 0,002185274539463314
            Epoch 19440/20000, Loss: 0,002185158807576055
            Epoch 19441/20000, Loss: 0,0021850430867074158
            Epoch 19442/20000, Loss: 0,0021849273768559593
            Epoch 19443/20000, Loss: 0,002184811678020242
            Epoch 19444/20000, Loss: 0,002184695990198825
            Epoch 19445/20000, Loss: 0,002184580313390268
            Epoch 19446/20000, Loss: 0,0021844646475931303
            Epoch 19447/20000, Loss: 0,0021843489928059733
            Epoch 19448/20000, Loss: 0,002184233349027359
            Epoch 19449/20000, Loss: 0,002184117716255844
            Epoch 19450/20000, Loss: 0,002184002094489994
            Epoch 19451/20000, Loss: 0,0021838864837283685
            Epoch 19452/20000, Loss: 0,00218377088396953
            Epoch 19453/20000, Loss: 0,002183655295212039
            Epoch 19454/20000, Loss: 0,00218353971745446
            Epoch 19455/20000, Loss: 0,0021834241506953544
            Epoch 19456/20000, Loss: 0,002183308594933284
            Epoch 19457/20000, Loss: 0,0021831930501668147
            Epoch 19458/20000, Loss: 0,0021830775163945064
            Epoch 19459/20000, Loss: 0,0021829619936149253
            Epoch 19460/20000, Loss: 0,002182846481826636
            Epoch 19461/20000, Loss: 0,0021827309810281996
            Epoch 19462/20000, Loss: 0,0021826154912181835
            Epoch 19463/20000, Loss: 0,0021825000123951504
            Epoch 19464/20000, Loss: 0,002182384544557667
            Epoch 19465/20000, Loss: 0,0021822690877042967
            Epoch 19466/20000, Loss: 0,002182153641833607
            Epoch 19467/20000, Loss: 0,002182038206944161
            Epoch 19468/20000, Loss: 0,0021819227830345267
            Epoch 19469/20000, Loss: 0,002181807370103271
            Epoch 19470/20000, Loss: 0,002181691968148959
            Epoch 19471/20000, Loss: 0,002181576577170158
            Epoch 19472/20000, Loss: 0,0021814611971654367
            Epoch 19473/20000, Loss: 0,0021813458281333595
            Epoch 19474/20000, Loss: 0,0021812304700724963
            Epoch 19475/20000, Loss: 0,002181115122981414
            Epoch 19476/20000, Loss: 0,002180999786858681
            Epoch 19477/20000, Loss: 0,0021808844617028666
            Epoch 19478/20000, Loss: 0,0021807691475125377
            Epoch 19479/20000, Loss: 0,0021806538442862644
            Epoch 19480/20000, Loss: 0,0021805385520226165
            Epoch 19481/20000, Loss: 0,0021804232707201645
            Epoch 19482/20000, Loss: 0,002180308000377474
            Epoch 19483/20000, Loss: 0,0021801927409931185
            Epoch 19484/20000, Loss: 0,002180077492565667
            Epoch 19485/20000, Loss: 0,002179962255093692
            Epoch 19486/20000, Loss: 0,002179847028575762
            Epoch 19487/20000, Loss: 0,0021797318130104488
            Epoch 19488/20000, Loss: 0,002179616608396325
            Epoch 19489/20000, Loss: 0,00217950141473196
            Epoch 19490/20000, Loss: 0,0021793862320159283
            Epoch 19491/20000, Loss: 0,0021792710602467993
            Epoch 19492/20000, Loss: 0,0021791558994231483
            Epoch 19493/20000, Loss: 0,0021790407495435446
            Epoch 19494/20000, Loss: 0,002178925610606565
            Epoch 19495/20000, Loss: 0,002178810482610779
            Epoch 19496/20000, Loss: 0,002178695365554764
            Epoch 19497/20000, Loss: 0,0021785802594370897
            Epoch 19498/20000, Loss: 0,0021784651642563335
            Epoch 19499/20000, Loss: 0,002178350080011068
            Epoch 19500/20000, Loss: 0,0021782350066998674
            Epoch 19501/20000, Loss: 0,0021781199443213087
            Epoch 19502/20000, Loss: 0,002178004892873964
            Epoch 19503/20000, Loss: 0,0021778898523564104
            Epoch 19504/20000, Loss: 0,002177774822767224
            Epoch 19505/20000, Loss: 0,002177659804104979
            Epoch 19506/20000, Loss: 0,002177544796368253
            Epoch 19507/20000, Loss: 0,0021774297995556208
            Epoch 19508/20000, Loss: 0,0021773148136656627
            Epoch 19509/20000, Loss: 0,002177199838696949
            Epoch 19510/20000, Loss: 0,0021770848746480646
            Epoch 19511/20000, Loss: 0,002176969921517581
            Epoch 19512/20000, Loss: 0,0021768549793040786
            Epoch 19513/20000, Loss: 0,0021767400480061346
            Epoch 19514/20000, Loss: 0,0021766251276223274
            Epoch 19515/20000, Loss: 0,0021765102181512375
            Epoch 19516/20000, Loss: 0,0021763953195914404
            Epoch 19517/20000, Loss: 0,0021762804319415156
            Epoch 19518/20000, Loss: 0,0021761655552000455
            Epoch 19519/20000, Loss: 0,002176050689365607
            Epoch 19520/20000, Loss: 0,0021759358344367805
            Epoch 19521/20000, Loss: 0,0021758209904121444
            Epoch 19522/20000, Loss: 0,0021757061572902814
            Epoch 19523/20000, Loss: 0,0021755913350697724
            Epoch 19524/20000, Loss: 0,002175476523749197
            Epoch 19525/20000, Loss: 0,0021753617233271363
            Epoch 19526/20000, Loss: 0,0021752469338021728
            Epoch 19527/20000, Loss: 0,0021751321551728856
            Epoch 19528/20000, Loss: 0,0021750173874378596
            Epoch 19529/20000, Loss: 0,002174902630595676
            Epoch 19530/20000, Loss: 0,002174787884644915
            Epoch 19531/20000, Loss: 0,0021746731495841634
            Epoch 19532/20000, Loss: 0,0021745584254120017
            Epoch 19533/20000, Loss: 0,0021744437121270135
            Epoch 19534/20000, Loss: 0,002174329009727781
            Epoch 19535/20000, Loss: 0,0021742143182128903
            Epoch 19536/20000, Loss: 0,002174099637580923
            Epoch 19537/20000, Loss: 0,0021739849678304663
            Epoch 19538/20000, Loss: 0,0021738703089601023
            Epoch 19539/20000, Loss: 0,0021737556609684157
            Epoch 19540/20000, Loss: 0,0021736410238539948
            Epoch 19541/20000, Loss: 0,0021735263976154196
            Epoch 19542/20000, Loss: 0,0021734117822512808
            Epoch 19543/20000, Loss: 0,0021732971777601606
            Epoch 19544/20000, Loss: 0,0021731825841406482
            Epoch 19545/20000, Loss: 0,002173068001391326
            Epoch 19546/20000, Loss: 0,0021729534295107855
            Epoch 19547/20000, Loss: 0,0021728388684976096
            Epoch 19548/20000, Loss: 0,0021727243183503877
            Epoch 19549/20000, Loss: 0,002172609779067706
            Epoch 19550/20000, Loss: 0,002172495250648153
            Epoch 19551/20000, Loss: 0,002172380733090315
            Epoch 19552/20000, Loss: 0,0021722662263927825
            Epoch 19553/20000, Loss: 0,0021721517305541413
            Epoch 19554/20000, Loss: 0,002172037245572982
            Epoch 19555/20000, Loss: 0,0021719227714478936
            Epoch 19556/20000, Loss: 0,002171808308177465
            Epoch 19557/20000, Loss: 0,0021716938557602853
            Epoch 19558/20000, Loss: 0,002171579414194942
            Epoch 19559/20000, Loss: 0,00217146498348003
            Epoch 19560/20000, Loss: 0,002171350563614136
            Epoch 19561/20000, Loss: 0,0021712361545958517
            Epoch 19562/20000, Loss: 0,002171121756423769
            Epoch 19563/20000, Loss: 0,0021710073690964764
            Epoch 19564/20000, Loss: 0,002170892992612568
            Epoch 19565/20000, Loss: 0,0021707786269706325
            Epoch 19566/20000, Loss: 0,002170664272169263
            Epoch 19567/20000, Loss: 0,002170549928207051
            Epoch 19568/20000, Loss: 0,0021704355950825905
            Epoch 19569/20000, Loss: 0,002170321272794473
            Epoch 19570/20000, Loss: 0,00217020696134129
            Epoch 19571/20000, Loss: 0,0021700926607216373
            Epoch 19572/20000, Loss: 0,002169978370934106
            Epoch 19573/20000, Loss: 0,0021698640919772917
            Epoch 19574/20000, Loss: 0,0021697498238497856
            Epoch 19575/20000, Loss: 0,0021696355665501857
            Epoch 19576/20000, Loss: 0,002169521320077081
            Epoch 19577/20000, Loss: 0,002169407084429071
            Epoch 19578/20000, Loss: 0,002169292859604749
            Epoch 19579/20000, Loss: 0,002169178645602709
            Epoch 19580/20000, Loss: 0,002169064442421548
            Epoch 19581/20000, Loss: 0,002168950250059862
            Epoch 19582/20000, Loss: 0,002168836068516245
            Epoch 19583/20000, Loss: 0,0021687218977892936
            Epoch 19584/20000, Loss: 0,002168607737877606
            Epoch 19585/20000, Loss: 0,0021684935887797763
            Epoch 19586/20000, Loss: 0,002168379450494405
            Epoch 19587/20000, Loss: 0,002168265323020085
            Epoch 19588/20000, Loss: 0,0021681512063554185
            Epoch 19589/20000, Loss: 0,0021680371004989996
            Epoch 19590/20000, Loss: 0,002167923005449427
            Epoch 19591/20000, Loss: 0,0021678089212052993
            Epoch 19592/20000, Loss: 0,0021676948477652156
            Epoch 19593/20000, Loss: 0,0021675807851277737
            Epoch 19594/20000, Loss: 0,0021674667332915736
            Epoch 19595/20000, Loss: 0,0021673526922552145
            Epoch 19596/20000, Loss: 0,0021672386620172944
            Epoch 19597/20000, Loss: 0,0021671246425764147
            Epoch 19598/20000, Loss: 0,0021670106339311736
            Epoch 19599/20000, Loss: 0,0021668966360801744
            Epoch 19600/20000, Loss: 0,0021667826490220153
            Epoch 19601/20000, Loss: 0,0021666686727552973
            Epoch 19602/20000, Loss: 0,0021665547072786226
            Epoch 19603/20000, Loss: 0,002166440752590592
            Epoch 19604/20000, Loss: 0,002166326808689805
            Epoch 19605/20000, Loss: 0,0021662128755748676
            Epoch 19606/20000, Loss: 0,002166098953244378
            Epoch 19607/20000, Loss: 0,0021659850416969424
            Epoch 19608/20000, Loss: 0,002165871140931159
            Epoch 19609/20000, Loss: 0,0021657572509456344
            Epoch 19610/20000, Loss: 0,0021656433717389682
            Epoch 19611/20000, Loss: 0,002165529503309766
            Epoch 19612/20000, Loss: 0,002165415645656632
            Epoch 19613/20000, Loss: 0,002165301798778169
            Epoch 19614/20000, Loss: 0,0021651879626729807
            Epoch 19615/20000, Loss: 0,002165074137339673
            Epoch 19616/20000, Loss: 0,002164960322776848
            Epoch 19617/20000, Loss: 0,0021648465189831136
            Epoch 19618/20000, Loss: 0,0021647327259570735
            Epoch 19619/20000, Loss: 0,0021646189436973313
            Epoch 19620/20000, Loss: 0,0021645051722024968
            Epoch 19621/20000, Loss: 0,0021643914114711717
            Epoch 19622/20000, Loss: 0,0021642776615019644
            Epoch 19623/20000, Loss: 0,002164163922293482
            Epoch 19624/20000, Loss: 0,0021640501938443293
            Epoch 19625/20000, Loss: 0,002163936476153114
            Epoch 19626/20000, Loss: 0,0021638227692184426
            Epoch 19627/20000, Loss: 0,002163709073038924
            Epoch 19628/20000, Loss: 0,002163595387613164
            Epoch 19629/20000, Loss: 0,0021634817129397733
            Epoch 19630/20000, Loss: 0,0021633680490173576
            Epoch 19631/20000, Loss: 0,0021632543958445254
            Epoch 19632/20000, Loss: 0,0021631407534198873
            Epoch 19633/20000, Loss: 0,002163027121742051
            Epoch 19634/20000, Loss: 0,002162913500809626
            Epoch 19635/20000, Loss: 0,00216279989062122
            Epoch 19636/20000, Loss: 0,002162686291175445
            Epoch 19637/20000, Loss: 0,00216257270247091
            Epoch 19638/20000, Loss: 0,002162459124506227
            Epoch 19639/20000, Loss: 0,0021623455572800016
            Epoch 19640/20000, Loss: 0,0021622320007908505
            Epoch 19641/20000, Loss: 0,0021621184550373812
            Epoch 19642/20000, Loss: 0,002162004920018205
            Epoch 19643/20000, Loss: 0,002161891395731934
            Epoch 19644/20000, Loss: 0,0021617778821771826
            Epoch 19645/20000, Loss: 0,0021616643793525565
            Epoch 19646/20000, Loss: 0,002161550887256673
            Epoch 19647/20000, Loss: 0,0021614374058881443
            Epoch 19648/20000, Loss: 0,002161323935245579
            Epoch 19649/20000, Loss: 0,0021612104753275943
            Epoch 19650/20000, Loss: 0,002161097026132804
            Epoch 19651/20000, Loss: 0,002160983587659818
            Epoch 19652/20000, Loss: 0,0021608701599072516
            Epoch 19653/20000, Loss: 0,0021607567428737202
            Epoch 19654/20000, Loss: 0,0021606433365578353
            Epoch 19655/20000, Loss: 0,0021605299409582133
            Epoch 19656/20000, Loss: 0,0021604165560734686
            Epoch 19657/20000, Loss: 0,002160303181902217
            Epoch 19658/20000, Loss: 0,0021601898184430723
            Epoch 19659/20000, Loss: 0,0021600764656946503
            Epoch 19660/20000, Loss: 0,002159963123655567
            Epoch 19661/20000, Loss: 0,002159849792324438
            Epoch 19662/20000, Loss: 0,0021597364716998803
            Epoch 19663/20000, Loss: 0,00215962316178051
            Epoch 19664/20000, Loss: 0,002159509862564945
            Epoch 19665/20000, Loss: 0,0021593965740518005
            Epoch 19666/20000, Loss: 0,002159283296239693
            Epoch 19667/20000, Loss: 0,002159170029127243
            Epoch 19668/20000, Loss: 0,0021590567727130658
            Epoch 19669/20000, Loss: 0,0021589435269957803
            Epoch 19670/20000, Loss: 0,0021588302919740053
            Epoch 19671/20000, Loss: 0,0021587170676463574
            Epoch 19672/20000, Loss: 0,0021586038540114577
            Epoch 19673/20000, Loss: 0,0021584906510679247
            Epoch 19674/20000, Loss: 0,002158377458814375
            Epoch 19675/20000, Loss: 0,0021582642772494326
            Epoch 19676/20000, Loss: 0,002158151106371713
            Epoch 19677/20000, Loss: 0,002158037946179838
            Epoch 19678/20000, Loss: 0,002157924796672429
            Epoch 19679/20000, Loss: 0,002157811657848104
            Epoch 19680/20000, Loss: 0,0021576985297054856
            Epoch 19681/20000, Loss: 0,002157585412243195
            Epoch 19682/20000, Loss: 0,0021574723054598515
            Epoch 19683/20000, Loss: 0,0021573592093540785
            Epoch 19684/20000, Loss: 0,002157246123924497
            Epoch 19685/20000, Loss: 0,0021571330491697285
            Epoch 19686/20000, Loss: 0,002157019985088395
            Epoch 19687/20000, Loss: 0,002156906931679122
            Epoch 19688/20000, Loss: 0,0021567938889405286
            Epoch 19689/20000, Loss: 0,0021566808568712396
            Epoch 19690/20000, Loss: 0,0021565678354698763
            Epoch 19691/20000, Loss: 0,0021564548247350645
            Epoch 19692/20000, Loss: 0,002156341824665426
            Epoch 19693/20000, Loss: 0,0021562288352595864
            Epoch 19694/20000, Loss: 0,0021561158565161706
            Epoch 19695/20000, Loss: 0,0021560028884338002
            Epoch 19696/20000, Loss: 0,0021558899310111035
            Epoch 19697/20000, Loss: 0,0021557769842467005
            Epoch 19698/20000, Loss: 0,0021556640481392208
            Epoch 19699/20000, Loss: 0,0021555511226872878
            Epoch 19700/20000, Loss: 0,0021554382078895285
            Epoch 19701/20000, Loss: 0,002155325303744567
            Epoch 19702/20000, Loss: 0,002155212410251032
            Epoch 19703/20000, Loss: 0,002155099527407547
            Epoch 19704/20000, Loss: 0,0021549866552127415
            Epoch 19705/20000, Loss: 0,0021548737936652406
            Epoch 19706/20000, Loss: 0,002154760942763672
            Epoch 19707/20000, Loss: 0,002154648102506664
            Epoch 19708/20000, Loss: 0,0021545352728928424
            Epoch 19709/20000, Loss: 0,0021544224539208367
            Epoch 19710/20000, Loss: 0,002154309645589274
            Epoch 19711/20000, Loss: 0,002154196847896784
            Epoch 19712/20000, Loss: 0,0021540840608419943
            Epoch 19713/20000, Loss: 0,002153971284423535
            Epoch 19714/20000, Loss: 0,002153858518640032
            Epoch 19715/20000, Loss: 0,0021537457634901187
            Epoch 19716/20000, Loss: 0,002153633018972422
            Epoch 19717/20000, Loss: 0,0021535202850855744
            Epoch 19718/20000, Loss: 0,002153407561828203
            Epoch 19719/20000, Loss: 0,0021532948491989412
            Epoch 19720/20000, Loss: 0,0021531821471964174
            Epoch 19721/20000, Loss: 0,002153069455819263
            Epoch 19722/20000, Loss: 0,0021529567750661087
            Epoch 19723/20000, Loss: 0,0021528441049355872
            Epoch 19724/20000, Loss: 0,0021527314454263305
            Epoch 19725/20000, Loss: 0,002152618796536967
            Epoch 19726/20000, Loss: 0,0021525061582661313
            Epoch 19727/20000, Loss: 0,0021523935306124566
            Epoch 19728/20000, Loss: 0,0021522809135745757
            Epoch 19729/20000, Loss: 0,002152168307151118
            Epoch 19730/20000, Loss: 0,0021520557113407198
            Epoch 19731/20000, Loss: 0,0021519431261420134
            Epoch 19732/20000, Loss: 0,0021518305515536313
            Epoch 19733/20000, Loss: 0,0021517179875742095
            Epoch 19734/20000, Loss: 0,0021516054342023807
            Epoch 19735/20000, Loss: 0,002151492891436779
            Epoch 19736/20000, Loss: 0,0021513803592760395
            Epoch 19737/20000, Loss: 0,002151267837718798
            Epoch 19738/20000, Loss: 0,0021511553267636865
            Epoch 19739/20000, Loss: 0,002151042826409342
            Epoch 19740/20000, Loss: 0,0021509303366544007
            Epoch 19741/20000, Loss: 0,0021508178574974985
            Epoch 19742/20000, Loss: 0,002150705388937271
            Epoch 19743/20000, Loss: 0,0021505929309723524
            Epoch 19744/20000, Loss: 0,0021504804836013813
            Epoch 19745/20000, Loss: 0,0021503680468229944
            Epoch 19746/20000, Loss: 0,002150255620635829
            Epoch 19747/20000, Loss: 0,002150143205038521
            Epoch 19748/20000, Loss: 0,0021500308000297085
            Epoch 19749/20000, Loss: 0,0021499184056080296
            Epoch 19750/20000, Loss: 0,0021498060217721208
            Epoch 19751/20000, Loss: 0,0021496936485206233
            Epoch 19752/20000, Loss: 0,002149581285852172
            Epoch 19753/20000, Loss: 0,0021494689337654073
            Epoch 19754/20000, Loss: 0,0021493565922589696
            Epoch 19755/20000, Loss: 0,0021492442613314953
            Epoch 19756/20000, Loss: 0,002149131940981624
            Epoch 19757/20000, Loss: 0,002149019631207997
            Epoch 19758/20000, Loss: 0,0021489073320092545
            Epoch 19759/20000, Loss: 0,0021487950433840353
            Epoch 19760/20000, Loss: 0,002148682765330979
            Epoch 19761/20000, Loss: 0,002148570497848729
            Epoch 19762/20000, Loss: 0,0021484582409359225
            Epoch 19763/20000, Loss: 0,002148345994591205
            Epoch 19764/20000, Loss: 0,002148233758813212
            Epoch 19765/20000, Loss: 0,0021481215336005928
            Epoch 19766/20000, Loss: 0,0021480093189519818
            Epoch 19767/20000, Loss: 0,0021478971148660253
            Epoch 19768/20000, Loss: 0,0021477849213413637
            Epoch 19769/20000, Loss: 0,0021476727383766404
            Epoch 19770/20000, Loss: 0,0021475605659704994
            Epoch 19771/20000, Loss: 0,0021474484041215814
            Epoch 19772/20000, Loss: 0,0021473362528285304
            Epoch 19773/20000, Loss: 0,002147224112089991
            Epoch 19774/20000, Loss: 0,0021471119819046064
            Epoch 19775/20000, Loss: 0,0021469998622710195
            Epoch 19776/20000, Loss: 0,0021468877531878768
            Epoch 19777/20000, Loss: 0,0021467756546538204
            Epoch 19778/20000, Loss: 0,002146663566667495
            Epoch 19779/20000, Loss: 0,0021465514892275482
            Epoch 19780/20000, Loss: 0,0021464394223326233
            Epoch 19781/20000, Loss: 0,0021463273659813654
            Epoch 19782/20000, Loss: 0,0021462153201724206
            Epoch 19783/20000, Loss: 0,002146103284904436
            Epoch 19784/20000, Loss: 0,0021459912601760564
            Epoch 19785/20000, Loss: 0,0021458792459859285
            Epoch 19786/20000, Loss: 0,0021457672423326976
            Epoch 19787/20000, Loss: 0,002145655249215013
            Epoch 19788/20000, Loss: 0,002145543266631521
            Epoch 19789/20000, Loss: 0,0021454312945808694
            Epoch 19790/20000, Loss: 0,0021453193330617038
            Epoch 19791/20000, Loss: 0,0021452073820726744
            Epoch 19792/20000, Loss: 0,002145095441612427
            Epoch 19793/20000, Loss: 0,0021449835116796124
            Epoch 19794/20000, Loss: 0,0021448715922728757
            Epoch 19795/20000, Loss: 0,0021447596833908695
            Epoch 19796/20000, Loss: 0,002144647785032241
            Epoch 19797/20000, Loss: 0,0021445358971956393
            Epoch 19798/20000, Loss: 0,0021444240198797157
            Epoch 19799/20000, Loss: 0,002144312153083117
            Epoch 19800/20000, Loss: 0,0021442002968044952
            Epoch 19801/20000, Loss: 0,0021440884510425
            Epoch 19802/20000, Loss: 0,0021439766157957817
            Epoch 19803/20000, Loss: 0,00214386479106299
            Epoch 19804/20000, Loss: 0,002143752976842778
            Epoch 19805/20000, Loss: 0,002143641173133796
            Epoch 19806/20000, Loss: 0,002143529379934696
            Epoch 19807/20000, Loss: 0,0021434175972441277
            Epoch 19808/20000, Loss: 0,002143305825060745
            Epoch 19809/20000, Loss: 0,0021431940633831995
            Epoch 19810/20000, Loss: 0,0021430823122101416
            Epoch 19811/20000, Loss: 0,0021429705715402267
            Epoch 19812/20000, Loss: 0,0021428588413721058
            Epoch 19813/20000, Loss: 0,0021427471217044343
            Epoch 19814/20000, Loss: 0,0021426354125358635
            Epoch 19815/20000, Loss: 0,0021425237138650464
            Epoch 19816/20000, Loss: 0,002142412025690638
            Epoch 19817/20000, Loss: 0,002142300348011292
            Epoch 19818/20000, Loss: 0,0021421886808256647
            Epoch 19819/20000, Loss: 0,002142077024132406
            Epoch 19820/20000, Loss: 0,0021419653779301733
            Epoch 19821/20000, Loss: 0,002141853742217623
            Epoch 19822/20000, Loss: 0,0021417421169934074
            Epoch 19823/20000, Loss: 0,0021416305022561853
            Epoch 19824/20000, Loss: 0,002141518898004609
            Epoch 19825/20000, Loss: 0,002141407304237337
            Epoch 19826/20000, Loss: 0,0021412957209530235
            Epoch 19827/20000, Loss: 0,0021411841481503253
            Epoch 19828/20000, Loss: 0,0021410725858279
            Epoch 19829/20000, Loss: 0,0021409610339844045
            Epoch 19830/20000, Loss: 0,0021408494926184944
            Epoch 19831/20000, Loss: 0,0021407379617288287
            Epoch 19832/20000, Loss: 0,002140626441314064
            Epoch 19833/20000, Loss: 0,002140514931372858
            Epoch 19834/20000, Loss: 0,0021404034319038676
            Epoch 19835/20000, Loss: 0,002140291942905755
            Epoch 19836/20000, Loss: 0,0021401804643771745
            Epoch 19837/20000, Loss: 0,002140068996316787
            Epoch 19838/20000, Loss: 0,0021399575387232523
            Epoch 19839/20000, Loss: 0,002139846091595228
            Epoch 19840/20000, Loss: 0,0021397346549313734
            Epoch 19841/20000, Loss: 0,0021396232287303487
            Epoch 19842/20000, Loss: 0,002139511812990813
            Epoch 19843/20000, Loss: 0,0021394004077114294
            Epoch 19844/20000, Loss: 0,002139289012890855
            Epoch 19845/20000, Loss: 0,002139177628527751
            Epoch 19846/20000, Loss: 0,00213906625462078
            Epoch 19847/20000, Loss: 0,0021389548911686014
            Epoch 19848/20000, Loss: 0,002138843538169877
            Epoch 19849/20000, Loss: 0,002138732195623269
            Epoch 19850/20000, Loss: 0,002138620863527438
            Epoch 19851/20000, Loss: 0,0021385095418810464
            Epoch 19852/20000, Loss: 0,002138398230682758
            Epoch 19853/20000, Loss: 0,002138286929931232
            Epoch 19854/20000, Loss: 0,0021381756396251354
            Epoch 19855/20000, Loss: 0,002138064359763127
            Epoch 19856/20000, Loss: 0,0021379530903438736
            Epoch 19857/20000, Loss: 0,002137841831366037
            Epoch 19858/20000, Loss: 0,0021377305828282796
            Epoch 19859/20000, Loss: 0,0021376193447292667
            Epoch 19860/20000, Loss: 0,002137508117067663
            Epoch 19861/20000, Loss: 0,002137396899842132
            Epoch 19862/20000, Loss: 0,002137285693051338
            Epoch 19863/20000, Loss: 0,0021371744966939463
            Epoch 19864/20000, Loss: 0,002137063310768623
            Epoch 19865/20000, Loss: 0,0021369521352740304
            Epoch 19866/20000, Loss: 0,002136840970208837
            Epoch 19867/20000, Loss: 0,0021367298155717074
            Epoch 19868/20000, Loss: 0,0021366186713613084
            Epoch 19869/20000, Loss: 0,002136507537576305
            Epoch 19870/20000, Loss: 0,002136396414215364
            Epoch 19871/20000, Loss: 0,0021362853012771533
            Epoch 19872/20000, Loss: 0,002136174198760338
            Epoch 19873/20000, Loss: 0,0021360631066635865
            Epoch 19874/20000, Loss: 0,002135952024985563
            Epoch 19875/20000, Loss: 0,002135840953724942
            Epoch 19876/20000, Loss: 0,002135729892880386
            Epoch 19877/20000, Loss: 0,002135618842450564
            Epoch 19878/20000, Loss: 0,0021355078024341443
            Epoch 19879/20000, Loss: 0,002135396772829796
            Epoch 19880/20000, Loss: 0,002135285753636187
            Epoch 19881/20000, Loss: 0,0021351747448519888
            Epoch 19882/20000, Loss: 0,0021350637464758676
            Epoch 19883/20000, Loss: 0,002134952758506494
            Epoch 19884/20000, Loss: 0,0021348417809425387
            Epoch 19885/20000, Loss: 0,002134730813782671
            Epoch 19886/20000, Loss: 0,0021346198570255594
            Epoch 19887/20000, Loss: 0,002134508910669876
            Epoch 19888/20000, Loss: 0,0021343979747142916
            Epoch 19889/20000, Loss: 0,002134287049157477
            Epoch 19890/20000, Loss: 0,002134176133998103
            Epoch 19891/20000, Loss: 0,0021340652292348395
            Epoch 19892/20000, Loss: 0,00213395433486636
            Epoch 19893/20000, Loss: 0,0021338434508913354
            Epoch 19894/20000, Loss: 0,002133732577308437
            Epoch 19895/20000, Loss: 0,002133621714116341
            Epoch 19896/20000, Loss: 0,0021335108613137156
            Epoch 19897/20000, Loss: 0,002133400018899234
            Epoch 19898/20000, Loss: 0,0021332891868715703
            Epoch 19899/20000, Loss: 0,002133178365229398
            Epoch 19900/20000, Loss: 0,002133067553971388
            Epoch 19901/20000, Loss: 0,0021329567530962183
            Epoch 19902/20000, Loss: 0,002132845962602559
            Epoch 19903/20000, Loss: 0,002132735182489085
            Epoch 19904/20000, Loss: 0,002132624412754471
            Epoch 19905/20000, Loss: 0,002132513653397391
            Epoch 19906/20000, Loss: 0,0021324029044165202
            Epoch 19907/20000, Loss: 0,0021322921658105355
            Epoch 19908/20000, Loss: 0,0021321814375781087
            Epoch 19909/20000, Loss: 0,0021320707197179174
            Epoch 19910/20000, Loss: 0,002131960012228636
            Epoch 19911/20000, Loss: 0,0021318493151089406
            Epoch 19912/20000, Loss: 0,0021317386283575095
            Epoch 19913/20000, Loss: 0,0021316279519730174
            Epoch 19914/20000, Loss: 0,002131517285954139
            Epoch 19915/20000, Loss: 0,002131406630299555
            Epoch 19916/20000, Loss: 0,0021312959850079403
            Epoch 19917/20000, Loss: 0,0021311853500779717
            Epoch 19918/20000, Loss: 0,002131074725508327
            Epoch 19919/20000, Loss: 0,0021309641112976863
            Epoch 19920/20000, Loss: 0,002130853507444724
            Epoch 19921/20000, Loss: 0,002130742913948121
            Epoch 19922/20000, Loss: 0,0021306323308065535
            Epoch 19923/20000, Loss: 0,0021305217580187023
            Epoch 19924/20000, Loss: 0,002130411195583245
            Epoch 19925/20000, Loss: 0,002130300643498861
            Epoch 19926/20000, Loss: 0,0021301901017642295
            Epoch 19927/20000, Loss: 0,002130079570378029
            Epoch 19928/20000, Loss: 0,0021299690493389424
            Epoch 19929/20000, Loss: 0,0021298585386456473
            Epoch 19930/20000, Loss: 0,002129748038296825
            Epoch 19931/20000, Loss: 0,002129637548291153
            Epoch 19932/20000, Loss: 0,0021295270686273174
            Epoch 19933/20000, Loss: 0,0021294165993039947
            Epoch 19934/20000, Loss: 0,0021293061403198682
            Epoch 19935/20000, Loss: 0,002129195691673618
            Epoch 19936/20000, Loss: 0,0021290852533639272
            Epoch 19937/20000, Loss: 0,002128974825389475
            Epoch 19938/20000, Loss: 0,002128864407748946
            Epoch 19939/20000, Loss: 0,0021287540004410223
            Epoch 19940/20000, Loss: 0,0021286436034643834
            Epoch 19941/20000, Loss: 0,0021285332168177176
            Epoch 19942/20000, Loss: 0,0021284228404997033
            Epoch 19943/20000, Loss: 0,0021283124745090248
            Epoch 19944/20000, Loss: 0,0021282021188443667
            Epoch 19945/20000, Loss: 0,0021280917735044106
            Epoch 19946/20000, Loss: 0,002127981438487843
            Epoch 19947/20000, Loss: 0,0021278711137933436
            Epoch 19948/20000, Loss: 0,0021277607994196032
            Epoch 19949/20000, Loss: 0,0021276504953653
            Epoch 19950/20000, Loss: 0,0021275402016291234
            Epoch 19951/20000, Loss: 0,0021274299182097558
            Epoch 19952/20000, Loss: 0,0021273196451058827
            Epoch 19953/20000, Loss: 0,0021272093823161897
            Epoch 19954/20000, Loss: 0,002127099129839364
            Epoch 19955/20000, Loss: 0,0021269888876740894
            Epoch 19956/20000, Loss: 0,0021268786558190523
            Epoch 19957/20000, Loss: 0,0021267684342729408
            Epoch 19958/20000, Loss: 0,0021266582230344386
            Epoch 19959/20000, Loss: 0,002126548022102236
            Epoch 19960/20000, Loss: 0,0021264378314750183
            Epoch 19961/20000, Loss: 0,002126327651151471
            Epoch 19962/20000, Loss: 0,002126217481130284
            Epoch 19963/20000, Loss: 0,002126107321410144
            Epoch 19964/20000, Loss: 0,0021259971719897386
            Epoch 19965/20000, Loss: 0,002125887032867758
            Epoch 19966/20000, Loss: 0,0021257769040428877
            Epoch 19967/20000, Loss: 0,002125666785513819
            Epoch 19968/20000, Loss: 0,0021255566772792377
            Epoch 19969/20000, Loss: 0,002125446579337835
            Epoch 19970/20000, Loss: 0,0021253364916883
            Epoch 19971/20000, Loss: 0,002125226414329321
            Epoch 19972/20000, Loss: 0,0021251163472595894
            Epoch 19973/20000, Loss: 0,002125006290477794
            Epoch 19974/20000, Loss: 0,0021248962439826243
            Epoch 19975/20000, Loss: 0,002124786207772772
            Epoch 19976/20000, Loss: 0,0021246761818469267
            Epoch 19977/20000, Loss: 0,0021245661662037804
            Epoch 19978/20000, Loss: 0,002124456160842024
            Epoch 19979/20000, Loss: 0,0021243461657603478
            Epoch 19980/20000, Loss: 0,002124236180957443
            Epoch 19981/20000, Loss: 0,002124126206432004
            Epoch 19982/20000, Loss: 0,002124016242182719
            Epoch 19983/20000, Loss: 0,002123906288208282
            Epoch 19984/20000, Loss: 0,002123796344507387
            Epoch 19985/20000, Loss: 0,0021236864110787228
            Epoch 19986/20000, Loss: 0,002123576487920986
            Epoch 19987/20000, Loss: 0,0021234665750328664
            Epoch 19988/20000, Loss: 0,0021233566724130604
            Epoch 19989/20000, Loss: 0,002123246780060259
            Epoch 19990/20000, Loss: 0,0021231368979731575
            Epoch 19991/20000, Loss: 0,0021230270261504485
            Epoch 19992/20000, Loss: 0,002122917164590828
            Epoch 19993/20000, Loss: 0,0021228073132929875
            Epoch 19994/20000, Loss: 0,002122697472255626
            Epoch 19995/20000, Loss: 0,0021225876414774324
            Epoch 19996/20000, Loss: 0,002122477820957108
            Epoch 19997/20000, Loss: 0,0021223680106933437
            Epoch 19998/20000, Loss: 0,002122258210684837
            Epoch 19999/20000, Loss: 0,0021221484209302823
            Epoch 20000/20000, Loss: 0,0021220386414283767
            Testing trained RNN on physics sentences:
            Input: energy cannot be created or destroyed only transformed
            Predicted: cannot be created or destroyed only transformed

            Input: an object in motion stays in motion unless acted upon by external force
            Predicted: object in motion stays in motion unless acted upon by external force

            Input: the speed of light in vacuum is a fundamental constant of nature
            Predicted: speed of light in vacuum is a fundamental constant of nature

            Input: electrons occupy discrete energy levels around the nucleus of an atom
            Predicted: occupy discrete energy levels around the nucleus of an atom

            Input: gravitational force between two masses is directly proportional to their product and inversely proportional to square of distance
            Predicted: force between two masses is directly proportional to their product and inversely proportional to square of distance

            Input: ice age
            Predicted: is proportional would same

            Input: proton has
            Predicted: of continuous energy the
            */


            ImprovedRNN rnn = new ImprovedRNN(inputSize: embeddingDim, hiddenSize: hiddenSize, outputSize: embeddingDim, learningRate: learningRate);

            // Five longer physics-related sentences for training
            List<string[]> physicsSentences = new List<string[]>
                {
                    new string[] { "energy", "cannot", "be", "created", "or", "destroyed", "only", "transformed" },
                    new string[] { "an", "object", "in", "motion", "stays", "in", "motion", "unless", "acted", "upon", "by", "external", "force" },
                    new string[] { "the", "speed", "of", "light", "in", "vacuum", "is", "a", "fundamental", "constant", "of", "nature" },
                    new string[] { "electrons", "occupy", "discrete", "energy", "levels", "around", "the", "nucleus", "of", "an", "atom" },
                    new string[] { "gravitational", "force", "between", "two", "masses", "is", "directly", "proportional", "to", "their", "product", "and", "inversely", "proportional", "to", "square", "of", "distance" }
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
