namespace CovarianceContravariance
{
    public interface IVariant<out TCovariant, in TContravariant, TInvariant>
    {
        TCovariant Covariant();
        void Contravariant(TContravariant input);
        TInvariant Invariant(TInvariant input);
    }

}
