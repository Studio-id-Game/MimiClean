﻿namespace StudioIdGames.MimiClean_Sample.Domain.App.Adapter.Gateway
{
    using Abstract;
    using IAdapter;
    using IApp.UseCaseIO;

    /// <summary>
    /// <see cref="IMoveItem.IGateway"/> を実装します。コンソール入力を利用します。
    /// </summary>
    public class MoveItemGateway(string name = "MoveItem") : ConsoleGateway<MoveItemInput>(name), IMoveItem.IGateway
    {
        protected override MoveItemInput MakeInputProtected()
        {
            string name = Utility.ReadName();
            var (dx, dy) = Utility.ReadXY();

            return new MoveItemInput(name, dx, dy);
        }

        protected override string Print(MoveItemInput input)
        {
            return $"name : {input.name}, dx : {input.dx}, dy : {input.dy}";
        }
    }
}
