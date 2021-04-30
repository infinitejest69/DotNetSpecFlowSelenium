using FluentAssertions;
using TechTalk.SpecFlow;

namespace SpecFlowSelenium.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {

        private int number1 { get; set; }
        private int number2 { get; set; }
        private int result { get; set; }


        private readonly ScenarioContext _scenarioContext;

        public CalculatorStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            number1 = number;
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            number2 = number;
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            result = number1 + number2;
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            result.Should().Be(this.result);
        }
    }
}
