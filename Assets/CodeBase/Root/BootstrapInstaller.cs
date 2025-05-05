using Zenject;
using UnityEngine;

public class BootstrapInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        //base.InstallBindings();

        BindSaveLoadService();

        BindPersistentProgressService();

        BindStaticDataService();
    }

    private void BindStaticDataService() => 
        Container.BindInterfacesAndSelfTo<StaticDataService>().AsSingle();

    private void BindPersistentProgressService() => 
        Container.BindInterfacesAndSelfTo<PersistentProgressService>().AsSingle();

    private void BindSaveLoadService() => 
        Container.BindInterfacesAndSelfTo<SaveLoadService>().AsSingle();
}
