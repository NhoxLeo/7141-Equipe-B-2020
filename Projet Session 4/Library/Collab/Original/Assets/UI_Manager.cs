﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class UI_Manager : MonoBehaviour
{
    private Player _Player;

    [Header("Pannel SkillTree")]
    [SerializeField] private Text txt_SkillPointsNumber = null;

    [Header("Pannel Characteristic")]
    [SerializeField] private Text txt_Power = null;
    [SerializeField] private Text txt_PhysicalPower = null;
    [SerializeField] private Text txt_CriticalDamage = null;
    [SerializeField] private Text txt_HealthRegeneration = null;
    [SerializeField] private Text txt_MovementSpeed = null;

    [SerializeField] private Text txt_Vigilance = null;
    [SerializeField] private Text txt_AttackSpeed = null;
    [SerializeField] private Text txt_CriticalChance = null;
    [SerializeField] private Text txt_Evasion = null;
    [SerializeField] private Text txt_DashRegeneration = null;

    [SerializeField] private Text txt_Mind = null;
    [SerializeField] private Text txt_MagicalPower = null;
    [SerializeField] private Text txt_DamagePenetration = null;
    [SerializeField] private Text txt_Barrier = null;
    [SerializeField] private Text txt_Mana = null;

    [SerializeField] private Text txt_Resilience = null;
    [SerializeField] private Text txt_ThornDamage = null;
    [SerializeField] private Text txt_PhysicalResistance = null;
    [SerializeField] private Text txt_health = null;
    [SerializeField] private Text txt_DamageResistance = null;

    [SerializeField] private Text txt_WillPower = null;
    [SerializeField] private Text txt_CooldownReduction = null;
    [SerializeField] private Text txt_MagicalResistance = null;
    [SerializeField] private Text txt_ManaRegeneration = null;
    [SerializeField] private Text txt_BuffEnhancement = null;
    // Start is called before the first frame update
    [SerializeField] private Text txt_CharacteristicPoints = null;

    [Header("Character UI")]
    [SerializeField] private Image img_HealthBar = null;
    [SerializeField] private Image img_ManaBar = null;
    [SerializeField] private Image img_BarrierBar = null;
    [SerializeField] private Image img_XpBar = null;
    [SerializeField] private Text txt_NumbOfArmorStack = null;
    [SerializeField] private Text txt_Level = null;
    [SerializeField] private Text txt_DashCount = null;

    [Header("Panel Toggle")]
    [SerializeField] private GameObject[] panels = null;
    [SerializeField] private Selectable[] defaultButtons = null;

    void Start()
    {
        _Player = GameObject.Find("Player").GetComponent<Player>();
    }
    void Update()
    {
        
        txt_Power.text = _Player.Power.GetValue().ToString();
        txt_PhysicalPower.text = _Player.PowerPhysical.GetValue().ToString();
        txt_CriticalDamage.text = _Player.CriticalDamage.GetValue().ToString();
        txt_HealthRegeneration.text = _Player.HealthRegenRatio.GetValue().ToString();
        txt_MovementSpeed.text = _Player.MovementSpeed.GetValue().ToString();

        txt_Vigilance.text = _Player.Vigilance.GetValue().ToString();
        txt_AttackSpeed.text = _Player.AttackSpeed.GetValue().ToString();
        txt_CriticalChance.text = _Player.CriticalChance.GetValue().ToString();
        txt_Evasion.text = _Player.Evasion.GetValue().ToString();
        txt_DashRegeneration.text = _Player.DashRegenRatio.GetValue().ToString();

        txt_Mind.text = _Player.Mind.GetValue().ToString();
        txt_MagicalPower.text = _Player.PowerMagical.GetValue().ToString();
        txt_DamagePenetration.text = _Player.DamagePenetration.GetValue().ToString();
        txt_Barrier.text = _Player.BarrierMaximum.GetValue().ToString();
        txt_Mana.text = _Player.ManaMaximum.GetValue().ToString();

        txt_Resilience.text = _Player.Resilience.GetValue().ToString();
        txt_ThornDamage.text = _Player.DamageThorn.GetValue().ToString();
        txt_PhysicalResistance.text = _Player.ResistancePhysical.GetValue().ToString();
        txt_health.text = _Player.HealthMaximum.GetValue().ToString();
        txt_DamageResistance.text = _Player.ResistanceDamage.GetValue().ToString();

        txt_WillPower.text = _Player.WillPower.GetValue().ToString();
        txt_CooldownReduction.text = _Player.CooldownReduction.GetValue().ToString();
        txt_MagicalResistance.text = _Player.ResistanceMagical.GetValue().ToString();
        txt_ManaRegeneration.text = _Player.ManaRegenRatio.GetValue().ToString();
        txt_BuffEnhancement.text = _Player.BonusBuffRatio.GetValue().ToString();

        txt_CharacteristicPoints.text = _Player.CharacteristicsPoints.ToString();

        //UI gameplay du joueur
        img_HealthBar.fillAmount = _Player.HealthCurrent / _Player.HealthMaximum.GetValue();
        img_ManaBar.fillAmount = _Player.ManaCurrent / _Player.ManaMaximum.GetValue();
        img_BarrierBar.fillAmount = _Player.BarrierCurrent / _Player.BarrierMaximum.GetValue();
        txt_NumbOfArmorStack.text = ": " + _Player.ArmorStack.ToString();
        txt_DashCount.text = ": " + (int)_Player.DashCurrent;
        img_XpBar.fillAmount = _Player.ExperienceCurrent / _Player.ExperienceMaximum;
        txt_Level.text = "Level " + _Player.LevelCurrent.ToString();

        //Panel SkillTree
        txt_SkillPointsNumber.text = "SkillPoints: " + _Player.SkillPoints;

    }

    #region Methods
    public void PanelToggle(int position)
    {
        Input.ResetInputAxes();
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(position == i);
            if (position == i)
            {
                defaultButtons[i].Select();
            }

        }
        if(position >= 0 && position != 5 && position != 7)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void Cancel(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            PanelToggle(0);
        }
    }
    public void SkillPlacement()
    {

    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadScene(string level)
    {
        SceneManager.LoadScene(level);
    }

    #endregion
}
