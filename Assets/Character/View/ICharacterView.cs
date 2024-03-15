using System.Threading;
using Cysharp.Threading.Tasks;

namespace Character.View
{
    public interface ICharacterView
    {
        void Move();
        UniTask Jump(CancellationToken token = default);
    }
}