public class YellowBird : Bird
{

    protected override void FlyingSkill()
    {
        rgd.velocity = rgd.velocity * 2;
    }

}
