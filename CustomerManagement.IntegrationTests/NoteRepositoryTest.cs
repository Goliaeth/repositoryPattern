using CustomerManagement.BusinessEntities;
using CustomerManagement.Repositories;

namespace CustomerManagement.IntegrationTests
{
    public class NoteRepositoryTest
    {
        [Fact]
        public void ShouldBeAbleToCreateNoteRepository()
        {
            var repository = new NoteRepository();
            Assert.NotNull(repository);
        }

        [Fact]
        public void ShouldBeAbleToCreateNote()
        {
            var repository = new NoteRepository();
            var note = new Note
            {
                CustomerId = 1,
                NoteText = "Note 2"
            };
            var createdNote = repository.Create(note);
            Assert.NotNull(createdNote);
        }

        [Fact]
        public void ShouldBeAbleToReadNote()
        {
            var repository = new NoteRepository();
            var readedNote = repository.Read("4");
            Assert.NotNull(readedNote);
        }

        [Fact]
        public void ShouldBeAbleToReadNonexistentNote()
        {
            var repository = new NoteRepository();
            var readedNote = repository.Read("24455556");
            Assert.Null(readedNote);
        }

        [Fact]
        public void ShouldBeAbleToUpdateNote()
        {
            var repository = new NoteRepository();
            var note = new Note
            {
                Id = 4,
                CustomerId = 1,
                NoteText = "Updated note text"
            };
            var updatedNote = repository.Update(note);
            Assert.Equal(note.NoteText, updatedNote.NoteText);
        }

        [Fact]
        public void ShouldBeAbleToDeleteNote()
        {
            var repository = new NoteRepository();
            repository.Delete("15");
            var deletedNote = repository.Read("15");
            Assert.Null(deletedNote);
        }
    }
}
