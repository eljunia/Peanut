using System;

namespace Peanut.Services.MachineLearning
{
    public interface ISayingsCategorizer
    {
        string Categorize(string modelFile, string sayingContent);
    }
}
