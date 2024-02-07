﻿namespace Task5BodyMassIndexTests.RecomendationModule;

public class RecommenderTests
{
    [Theory, MemberData(nameof(MessagesSource))]
    public void RecommendationMessage(double index, string expected)
    {
        var calcMock = new Mock<ICommonCalculator>();
        calcMock.Setup(x => x.Index()).Returns(index);
        ITextRecommender recommender = Recommender.Create(RecommenderType.Messages);

        var actual = recommender.RecommendationText(calcMock.Object);

        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object[]> MessagesSource()
    {
        yield return new object[] { 15.0, "Выраженный дефицит массы тела. Немедленно набрать очень много веса!" };
        yield return new object[] { 18.0, "Недостаточная (дефицит) масса тела. Очень срочно набрать вес!" };
        yield return new object[] { 24.0, "Норма. Срочно набрать вес!" };
        yield return new object[] { 29.0, "Избыточная масса тела (предожирение). Немного набрать вес." };
        yield return new object[] { 34.0, "Ожирение (на самом деле это нормальный вес!). Все в порядке!" };
        yield return new object[] { 39.0, "Ожирение начальное. Немножечко сбросить вес!" };
        yield return new object[] { 41.0, "Очень сильное ожирение. Срочно сбросить вес!" };
    }

    [Theory, MemberData(nameof(CountsSource))]
    public void RecommendationCount(double index, double weight, double height, string expected)
    {
        var calcMock = new Mock<ICommonCalculator>();
        calcMock.Setup(x => x.Index()).Returns(index);
        calcMock.SetupGet(x => x.Weight).Returns(weight);
        calcMock.SetupGet(x => x.Height).Returns(height);
        ITextRecommender recommender = Recommender.Create(RecommenderType.Counts);

        var actual = recommender.RecommendationText(calcMock.Object);

        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object[]> CountsSource()
    {
        yield return new object[] { 18.0, 60, 1.5, "Человеку для того чтобы имено нормальный ИМТ (Легкое ожирение) нужно поправится на 7.5 килограмм." };
        yield return new object[] { 31.0, 80, 1.5, "Нормальный вес, корректировка не требуется." };
        yield return new object[] { 36.0, 110, 1.5, "Человеку для того чтобы имено нормальный ИМТ (Легкое ожирение) нужно похудеть на 31.2 килограмм." };
    }
}