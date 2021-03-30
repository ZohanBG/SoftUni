using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    [Test]
    public void DummyShouldLoseHealthWhenAttacked()
    {
        Dummy dummy = new Dummy(10, 10);
        dummy.TakeAttack(1);

        Assert.That(dummy.Health, Is.EqualTo(9));
    }

    [Test]
    public void DeadDummyShouldThrowExeptionWhenAttacked()
    {
        Dummy dummy = new Dummy(0,10);

        Assert.Throws<InvalidOperationException>(() =>
        {
            dummy.TakeAttack(1);
        });
    }

    [Test]
    public void DeadDummyShouldGiveExp()
    {
        Dummy dummy = new Dummy(0, 10);

        int exp = dummy.GiveExperience();

        Assert.That(exp, Is.EqualTo(10));
    }

    [Test]
    public void AliveDummyShouldThrowExeptionWhenAskedToGiveExp()
    {
        Dummy dummy = new Dummy(10, 10);

        Assert.Throws<InvalidOperationException>(() =>
        {
            dummy.GiveExperience();
        });
    }
}
