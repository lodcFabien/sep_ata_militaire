using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Components;

public class PopupManager : Singleton<PopupManager>
{
    [SerializeField] private Animator _animator;
    [SerializeField] private LocalizeStringEvent _title;
    [SerializeField] private LocalizeStringEvent _description;
    private ProductModel _currentModel;
    public ProductModel CurrentModel => _currentModel;

    public bool hasContent = false;

    public void Populate(ProductModel product)
    {
        _currentModel = product;

        if (product == null)
        {
            _animator.SetBool("Visible", false);
        }
        else
        {
            _animator.SetBool("Visible", true);
            _title.SetEntry(product.PopupName);
            _description.SetEntry(product.Description);
            ProductPreviewManager.Instance.SetCurrentProduct(product);
        }
    }

    public void OnBackStopHasContent()
    {
        StartCoroutine(StopHasContentCoroutine());
    }

    private IEnumerator StopHasContentCoroutine()
    {
        yield return new WaitForSeconds(1f);
        hasContent = false;
    }
}
