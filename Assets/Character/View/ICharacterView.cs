using System.Threading;
using Cysharp.Threading.Tasks;

namespace Character.View
{
    public interface ICharacterView
    {
        UniTask Move(CancellationToken token = default);
        UniTask Jump(CancellationToken token = default);
    }
}