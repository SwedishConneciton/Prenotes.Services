
using Prenotes.Services.Things;

namespace Prenotes.Services.Actions {

    public interface ICaretakerService {
        Caretaker Create(Caretaker obj, Handshake shake);
    }
}