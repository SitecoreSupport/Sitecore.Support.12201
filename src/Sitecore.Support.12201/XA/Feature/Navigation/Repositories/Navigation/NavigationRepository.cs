namespace Sitecore.Support.XA.Feature.Navigation.Repositories.Navigation
{
  using System.Linq;
  using Sitecore.Data.Items;
  using Sitecore.XA.Feature.Navigation;
  using Sitecore.XA.Feature.Navigation.Repositories.Breadcrumb;
  using Sitecore.XA.Foundation.RenderingVariants.Repositories;
  using Sitecore.XA.Foundation.SitecoreExtensions.Utils;

  public class NavigationRepository : Sitecore.XA.Feature.Navigation.Repositories.Navigation.NavigationRepository
  {
    public NavigationRepository(IVariantsRepository variantsRespository, IBreadcrumbRepository breadcrumbRepository) : base(variantsRespository, breadcrumbRepository)
    {
    }

    protected override string BuildNavigationClass(Item item)
    {
      var lookup = ItemUtils.Lookup(item[Templates._Navigable.Fields.NavigationClass], Context.Database);
      string navigationClass = lookup.Select(i => i["Value"]).FirstOrDefault();

      var variantItem = VariantsRespository.VariantItem;
      if (variantItem != null && !string.IsNullOrWhiteSpace(variantItem[Sitecore.XA.Foundation.RenderingVariants.Templates.VariantDefinition.Fields.ItemCssClassField]))
      {
        #region Original code
        //string cssClass = item[variantItem[Sitecore.XA.Foundation.RenderingVariants.Templates.VariantDefinition.Fields.ItemCssClassField]]; 
        #endregion
        #region Changed code
        string cssClass = variantItem[Sitecore.XA.Foundation.RenderingVariants.Templates.VariantDefinition.Fields.ItemCssClassField]; 
        #endregion
        if (!string.IsNullOrWhiteSpace(cssClass))
        {
          navigationClass = $"{navigationClass} {cssClass}".Trim();
        }
      }
      return navigationClass;
    }
  }
}