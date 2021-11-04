using UnityEngine;
using UnityEngine.UI;

public class I18NText : Text
{
    public int i18NId = -1;

    protected override void Awake()
    {
        base.Awake();
        if (!Application.isPlaying) return;
        // 根据当前的语言设置，比如中文、英语等，显示对应的语言的文本
        if (-1 != i18NId)
        {
            text = I18N.GetStr(i18NId);
        }

        EventDispatcher.instance.Regist(EventNameDef.LANGUAGE_TYPE_CHANGED, OnLanguageChange);
    }

    void OnLanguageChange(params object[] args)
    {
        if (-1 != i18NId)
        {
            text = I18N.GetStr(i18NId);
        }
    }

    protected override void OnDestroy()
    {
        EventDispatcher.instance.UnRegist(EventNameDef.LANGUAGE_TYPE_CHANGED, OnLanguageChange);
        base.OnDestroy();
    }
}
