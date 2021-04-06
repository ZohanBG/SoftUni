// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
	public class StageTests
    {
		private Stage stage;
		private Song song1;
		private Song song2;
		private Performer goodPerformer;
		private Performer badPerformer1;

		[SetUp]
        public void SetUp()
		{
			stage = new Stage();
			song1 = new Song("Ветрове", new TimeSpan(0, 3, 30));
			song2 = new Song("Бурни Нощи", new TimeSpan(0, 0, 30));
			goodPerformer = new Performer("Ivan", "Ivanov", 19);
			badPerformer1 = new Performer("Evtim", "Ivanov", 17);

		}

		[Test]
        public void ShouldThrowArgumentNullExceptionWhenNullPerformerIsAdded() 
		{
			Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(null));
		}

		[Test]
		public void ShouldThrowArgumentExceptionWhenPerformerUnder18IsAdded()
		{
			Assert.Throws<ArgumentException>(() => stage.AddPerformer(badPerformer1));
		}

		[Test]
		public void PerformerShouldBeAdded()
		{
			stage.AddPerformer(goodPerformer);
			Assert.That(goodPerformer, Is.EqualTo(stage.Performers.First()));
		}

		[Test]
		public void PerformerShouldBeAddedAgaing()
		{
			stage.AddPerformer(goodPerformer);
			Assert.That(1, Is.EqualTo(stage.Performers.Count));
		}

		[Test]
		public void ShouldThrowArgumentNullExceptionWhenNullSongIsAdded()
		{
			Assert.Throws<ArgumentNullException>(() => stage.AddSong(null));
		}

		[Test]
		public void ShouldThrowArgumentExceptionWhenSongUnder1MinuteIsAdded()
		{
			Assert.Throws<ArgumentException>(() => stage.AddSong(song2));
		}

		[Test]
		public void ShouldThrowArgumentExceptionWhenNullSongIsAddedToPerformer()
		{
			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(song1.Name,null));
		}

		[Test]
		public void ShouldThrowArgumentExceptionWhenSongIsAddedToNullPerformer()
		{
			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null,goodPerformer.FullName));
		}

		[Test]
		public void ShouldThrowArgumentExceptionWhenWrongPerformerNameIsSearched()
		{
			stage.AddSong(song1);

			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer(song1.Name, goodPerformer.FullName));
		}

		[Test]
		public void ShouldThrowArgumentExceptionWhenWrongSongNameIsSearched()
		{
			stage.AddPerformer(goodPerformer);
			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer(song1.Name, goodPerformer.FullName));
		}

		[Test]
		public void AddsASongToAPerformerList()
		{
			stage.AddPerformer(goodPerformer);
			stage.AddSong(song1);
			stage.AddSongToPerformer(song1.Name, goodPerformer.FullName);
			Assert.That(song1, Is.EqualTo(goodPerformer.SongList.First()));	
		}

		[Test]
		public void AddsASongToAPerformerListAgain()
		{
			stage.AddPerformer(goodPerformer);
			stage.AddSong(song1);
			stage.AddSongToPerformer(song1.Name, goodPerformer.FullName);
			Assert.That(1, Is.EqualTo(goodPerformer.SongList.Count));
		}

		[Test]
		public void Test_AddSongToPerformer()
		{
			stage.AddPerformer(goodPerformer);
			stage.AddSong(song1);

			var message = stage.AddSongToPerformer(song1.Name, goodPerformer.FullName);

			Assert.AreEqual($"{song1} will be performed by {goodPerformer}", message);
		}

		[Test]
		public void PlayWorks()
        {
			stage.AddPerformer(goodPerformer);
			stage.AddSong(song1);
			stage.AddSongToPerformer(song1.Name, goodPerformer.FullName);
			string result = stage.Play();
			Assert.That(result, Is.EqualTo("1 performers played 1 songs"));
		}

		[Test]
		public void TestConstructor()
		{
			Assert.AreEqual(0, stage.Performers.Count);
		}

	}
}